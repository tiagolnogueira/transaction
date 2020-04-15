using Core.Aggregate.TransactionAggregate;
using Xunit;

namespace UnitTest
{
    public class TransactionTest
    {
        [Fact]
        public void Create_Transaction()
        {
            var sourceAccount = new Account("123456", 10);
            var destinationAccount = new Account("987654", 10);

            var transaction = Transaction.CreateAsync(sourceAccount, destinationAccount, 5);

            Assert.Equal(5, sourceAccount.Balance);
            Assert.Equal(15, destinationAccount.Balance);
        }
    }
}
