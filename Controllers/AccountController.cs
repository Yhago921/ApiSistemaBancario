using Api.DTO;
using Api.Models;
using Api.Services.AccountS;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountInterface accountInterface;
        public AccountController(IAccountInterface accountInterface)
        {
            this.accountInterface = accountInterface;
        }
        [HttpPost("createAccount/{idUser}")]
        public async Task<ActionResult<ResponseModel<Account>>> CreateAccount(AccountDto accountDto, int idUser)
        {
            var account = await this.accountInterface.CreateAccount(accountDto, idUser);
            return Ok(account);
        }
    }
}