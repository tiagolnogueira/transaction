using System;
using System.Threading.Tasks;

namespace Core.Aggregate.TransactionAggregate
{
    public class Transaction : Entity
    {
        private Transaction(Account source, Account destination, Money money) : base(Guid.NewGuid())
        {
            Source = source;
            Destination = destination;
            Money = money;
        }
        
        public static async Task<Transaction> CreateAsync(Account source, Account destination, Money money)
        {
            var newTransaction = new Transaction(source, destination, money);

            await newTransaction.TransferMoney(money);

            return newTransaction;
        }
        
        public Account Source { get; private set; }

        public Account Destination { get; private set; }

        public Money Money { get; private set; }

        private async Task TransferMoney(Money money)
        {
            await Source.DecreaseBalance(money);

            await Destination.IncreaseBalance(money);
        }
    }
}
