namespace DwadTestRp.Data;

using DwadTestRp.Models;

public class TransactionLogRepository(ApplicationDbContext context) : ITransactionLogRepository
{
    public async Task AddAsync(TransactionLog log)
    {
        log.Timestamp = DateTime.UtcNow;
        context.TransactionLogs.Add(log);
        await context.SaveChangesAsync();
    }
}
