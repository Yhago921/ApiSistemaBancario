using Api.DTO;
using Api.Models;

namespace Api.Services.AccountS
{
    public interface IAccountInterface
    {
     Task<ResponseModel<Account>> CreateAccount(AccountDto accountDto, int idUser);

    }
}