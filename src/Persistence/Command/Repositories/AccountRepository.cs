using Application.Query.Transaction;
using Core.Aggregate.TransactionAggregate;
using Persistence.Command.Contexts;
using System;
using System.Threading.Tasks;

namespace Persistence.Command.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppAccountContext _appAccountContext;

        public AccountRepository(AppAccountContext appAccountContext)
            => _appAccountContext = appAccountContext ?? throw new ArgumentNullException($"'{nameof(_appAccountContext)}'");

        public async Task SaveAsync(Account account)
        {
            try
            {
                await _appAccountContext.SaveAsync(account);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}InnerException:{e.InnerException}");
                throw;
            }
        }

    }
}
