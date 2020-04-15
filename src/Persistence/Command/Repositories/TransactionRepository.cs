using Application.Query.Transaction;
using Core.Aggregate.TransactionAggregate;
using Persistence.Command.Contexts;
using System;
using System.Threading.Tasks;

namespace Persistence.Command.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppTransactionContext _appTransactionContext;

        public TransactionRepository(AppTransactionContext appTransactionContext)
            => _appTransactionContext = appTransactionContext ?? throw new ArgumentNullException($"'{nameof(appTransactionContext)}'");

        public async Task SaveAsync(Transaction transaction)
        {
            try
            {
                await _appTransactionContext.SaveAsync(transaction);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}InnerException:{e.InnerException}");
                throw;
            }
        }

    }
}
