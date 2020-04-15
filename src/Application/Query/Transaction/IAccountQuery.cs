using Core.Aggregate.TransactionAggregate;
using System.Threading.Tasks;

namespace Application.Query.Transaction
{
    public interface IAccountQuery
    {
        Task<Account> GetAsyncByAccountNumber(AccountNumber accountNumber);
    }
}
