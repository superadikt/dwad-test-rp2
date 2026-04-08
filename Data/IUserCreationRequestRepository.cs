using DwadTestRp.Models;

namespace DwadTestRp.Data;

public interface IUserCreationRequestRepository
{
    Task SubmitAsync(UserCreationRequest request);
    Task<List<UserCreationRequest>> GetPendingAsync();
    Task<UserCreationRequest?> GetByIdAsync(Guid requestId);
    Task ApproveAsync(Guid requestId, string approvedBy);
    Task RejectAsync(Guid requestId, string rejectedBy);
}
