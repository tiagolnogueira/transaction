using Core.Aggregate.TransactionAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Command.Contexts
{
    public class AppAccountContext
    {
        public AppAccountContext()
        {
            Accounts = new List<Account>
                {
                    new Account("123456", 100),
                    new Account("987654", 100)
                };
        }

        public ICollection<Account> Accounts { get; }

        public async Task SaveAsync(Account updatedAccount)
        {
            var account = Accounts.First(x => x.Id == updatedAccount.Id);
            account = updatedAccount;

            await Task.CompletedTask;
        }

    }
}
