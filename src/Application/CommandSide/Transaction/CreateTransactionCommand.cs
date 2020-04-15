using Application.Query.Transaction;
using System.Threading.Tasks;

namespace Application.CommandSide.Transaction
{
    public class CreateTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountQuery _accountQuery;

        public CreateTransactionCommand(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IAccountQuery accountQuery)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _accountQuery = accountQuery;
        }

        public async Task<CommandResult> CreateAsync(string sourceAccountNumber, string destinationAccountNumber, decimal value)
        {
            var sourceAccount = await _accountQuery.GetAsyncByAccountNumber(sourceAccountNumber);
            if (sourceAccount == null)
            {
                return CommandResult.NotFound("The Source Account Number does not exist, please verify the number!");
            }

            var destinationAccount = await _accountQuery.GetAsyncByAccountNumber(destinationAccountNumber);
            if (destinationAccount == null)
            {
                return CommandResult.NotFound("The Destination Account Number does not exist, please verify the number!");
            }

            var transaction = await Core.Aggregate.TransactionAggregate.Transaction.CreateAsync(sourceAccount, destinationAccount, value);

            try
            {
                await _transactionRepository.SaveAsync(transaction);

                await _accountRepository.SaveAsync(sourceAccount);
                await _accountRepository.SaveAsync(destinationAccount);
            }
            catch (System.Exception ex)
            {
                return CommandResult.BadRequest(ex.Message);
            }

            return CommandResult.Ok("Transaction created successfully.");
        }
    }
}
