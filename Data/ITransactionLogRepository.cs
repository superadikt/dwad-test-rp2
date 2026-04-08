using DwadTestRp.Models;

namespace DwadTestRp.Data;

public interface ITransactionLogRepository
{
    Task AddAsync(TransactionLog log);
}
