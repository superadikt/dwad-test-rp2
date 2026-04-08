using Microsoft.EntityFrameworkCore;
using DwadTestRp.Models;

namespace DwadTestRp.Data;

public class UserCreationRequestRepository(ApplicationDbContext context, IUserRepository userRepository, ITransactionLogRepository transactionLog) : IUserCreationRequestRepository
{
    public async Task SubmitAsync(UserCreationRequest request)
    {
        request.DateRequested = DateTime.UtcNow;
        request.Status = RequestStatus.Pending.ToString();
        context.UserCreationRequests.Add(request);
        await context.SaveChangesAsync();
    }

    public async Task<List<UserCreationRequest>> GetPendingAsync()
    {
        return await context.UserCreationRequests
            .Where(r => r.Status == RequestStatus.Pending.ToString())
            .OrderByDescending(r => r.DateRequested)
            .ToListAsync();
    }

    public async Task<UserCreationRequest?> GetByIdAsync(Guid requestId)
    {
        return await context.UserCreationRequests.FindAsync(requestId);
    }

    public async Task ApproveAsync(Guid requestId, string approvedBy)
    {
        var req = await context.UserCreationRequests.FindAsync(requestId);
        if (req is null)
            return;

        // Prevent duplicate emails
        var existing = await context.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
        if (existing is not null)
            throw new InvalidOperationException("A user with the same email already exists.");

        // Create user
        var names = req.FullName?.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
        var first = names.Length > 0 ? names[0] : req.FullName;
        var last = names.Length > 1 ? names[1] : string.Empty;

        var user = new Models.User
        {
            FirstName = first ?? string.Empty,
            LastName = last ?? string.Empty,
            Email = req.Email
        };

        // Use a transaction to ensure atomic operations
        using var tx = await context.Database.BeginTransactionAsync();
        try
        {
            await userRepository.AddAsync(user);

            req.Status = RequestStatus.Approved.ToString();
            req.DateApproved = DateTime.UtcNow;
            req.ApprovedBy = approvedBy;
            context.UserCreationRequests.Update(req);

            // Audit
            context.ApprovalAudits.Add(new ApprovalAudit
            {
                RequestId = req.RequestId,
                Action = "Approved",
                PerformedBy = approvedBy,
                PerformedAt = DateTime.UtcNow,
                Notes = "User created"
            });

            await context.SaveChangesAsync();

            // Transaction log entry
            var log = new TransactionLog
            {
                Module = "User Creation Approval",
                Action = "Approved User Creation Request",
                Entity = "UserCreationRequest",
                EntityId = req.RequestId.ToString(),
                PerformedBy = approvedBy,
                Details = $"FullName={req.FullName};Email={req.Email};Role={req.Role};RequestId={req.RequestId}"
            };
            await transactionLog.AddAsync(log);

            await tx.CommitAsync();
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }
    }

    public async Task RejectAsync(Guid requestId, string rejectedBy)
    {
        var req = await context.UserCreationRequests.FindAsync(requestId);
        if (req is null)
            return;
        using var tx = await context.Database.BeginTransactionAsync();
        try
        {
            req.Status = RequestStatus.Rejected.ToString();
            req.DateApproved = DateTime.UtcNow;
            req.ApprovedBy = rejectedBy;
            context.UserCreationRequests.Update(req);

            context.ApprovalAudits.Add(new ApprovalAudit
            {
                RequestId = req.RequestId,
                Action = "Rejected",
                PerformedBy = rejectedBy,
                PerformedAt = DateTime.UtcNow,
                Notes = "Request rejected"
            });

            await context.SaveChangesAsync();

            var log = new TransactionLog
            {
                Module = "User Creation Approval",
                Action = "Rejected User Creation Request",
                Entity = "UserCreationRequest",
                EntityId = req.RequestId.ToString(),
                PerformedBy = rejectedBy,
                Details = $"FullName={req.FullName};Email={req.Email};Role={req.Role};RequestId={req.RequestId}"
            };
            await transactionLog.AddAsync(log);

            await tx.CommitAsync();
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }
    }
}
