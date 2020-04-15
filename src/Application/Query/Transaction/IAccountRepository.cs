using Core.Aggregate.TransactionAggregate;
using System.Threading.Tasks;

namespace Application.Query.Transaction
{
    public interface IAccountRepository
    {
        Task SaveAsync(Account account);
    }
}
