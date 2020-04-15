using Application.Query.Transaction;
using Core.Aggregate.TransactionAggregate;
using Persistence.Command.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Queries.Transaction
{
    public class AccountQuery : IAccountQuery
    {
        private readonly AppAccountContext _appAccountContext;

        public AccountQuery(AppAccountContext appAccountContext)
            => _appAccountContext = appAccountContext ?? throw new ArgumentNullException($"'{nameof(appAccountContext)}'");

        public async Task<Account> GetAsyncByAccountNumber(AccountNumber accountNumber)
        {
            await Task.CompletedTask;
            return _appAccountContext.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
    }
}
