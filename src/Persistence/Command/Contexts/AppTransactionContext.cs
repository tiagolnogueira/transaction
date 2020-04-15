using Core.Aggregate.TransactionAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Command.Contexts
{
    public class AppTransactionContext
    {
        public AppTransactionContext()
        {
            Transactions = new List<Transaction>();
        }

        public ICollection<Transaction> Transactions { get; }

        public async Task SaveAsync(Transaction transaction)
        {
            Transactions.Add(transaction);

            await Task.CompletedTask;
        }
    }
}
