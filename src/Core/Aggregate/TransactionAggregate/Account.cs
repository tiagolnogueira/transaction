using System;
using System.Threading.Tasks;

namespace Core.Aggregate.TransactionAggregate
{
    public class Account : Entity
    {
        public Account(AccountNumber accountNumber, Money balance) : base(Guid.NewGuid())
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public Account(Guid id, AccountNumber accountNumber, Money balance) : base(id)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public AccountNumber AccountNumber { get; private set; }

        public Money Balance { get; private set; }

        //This method is not required to be async, since it's not accessing a database, but I decided to keep it for best practice and to be easier when we decide to use a DB instead.
        internal async Task IncreaseBalance(Money addedValue)
        {
            Balance += addedValue;

            await Task.CompletedTask;
        }

        //This method is not required to be async, since it's not accessing a database, but I decided to keep it for best practice and to be easier when we decide to use a DB instead.
        internal async Task DecreaseBalance(Money decreasedValue)
        {
            if ((Balance - decreasedValue) < 0)
                throw new ArithmeticException($"The Account '{AccountNumber.Value}' does not have this amount of money.");

            Balance -= decreasedValue;

            await Task.CompletedTask;
        }
    }
}
