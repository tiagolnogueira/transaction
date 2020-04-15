using System.Threading.Tasks;

namespace Application.Query.Transaction
{
    public interface ITransactionRepository
    {
        Task SaveAsync(Core.Aggregate.TransactionAggregate.Transaction transaction);
    }
}
