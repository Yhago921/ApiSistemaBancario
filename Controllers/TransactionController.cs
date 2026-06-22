using Api.Models;
using Api.Services.TransactionS;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionInterface transactionInterface;
        public TransactionController(ITransactionInterface transactionInterface)
        {
            this.transactionInterface = transactionInterface;
        }
        [HttpPost("Transferir/{FromAccountId}/{ToAccountId}/{Amount}")]
        public async Task<ActionResult<ResponseModel<Transaction>>> Transfer(int FromAccountId, int ToAccountId, decimal Amount)
        {
         var transaction = await this.transactionInterface.Transfer(FromAccountId, ToAccountId, Amount); 
         return Ok(transaction);  
        }
    }
}