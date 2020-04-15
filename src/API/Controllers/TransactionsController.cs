using API.Models;
using Application.CommandSide.Transaction;
using Application.Query.Transaction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountQuery _accountQuery;

        public TransactionsController(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IAccountQuery accountQuery)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _accountQuery = accountQuery;
        }

        // POST api/transactions
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionModel transactionModel)
        {
            try
            {
                var createTransactionCommand = new CreateTransactionCommand(_transactionRepository, _accountRepository, _accountQuery);

                var commandResult = await createTransactionCommand.CreateAsync(transactionModel.SourceAccountNumber, transactionModel.DestinationAccountNumber, transactionModel.Value);

                if (commandResult.Success)
                    return new OkObjectResult(commandResult);
                else
                {
                    if (commandResult.ErrorType == Application.CommandSide.CommandResult.ErrorTypes.NotFound)
                        return new NotFoundObjectResult(commandResult);
                    else
                        return new BadRequestObjectResult(commandResult);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
