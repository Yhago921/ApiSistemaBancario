using Api.Data;
using Api.DTO;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.AccountS
{
    public class AccountService : IAccountInterface
    {
        private readonly AppDBContext context;
        public AccountService(AppDBContext context)
        {
            this.context = context;
        }
        public async Task<ResponseModel<Account>> CreateAccount(AccountDto accountDto, int idUser)
        {
            ResponseModel<Account> response = new();
            try
            {
               bool userExist = await this.context.Users.FirstOrDefaultAsync(user => user.Id == idUser) != null;

               bool verifyAccountNumber = await this.context.Accounts.AnyAsync(account => account.AccountNumber == accountDto.AccountNumber) ;
               bool verifyAccountId = await this.context.Accounts.AnyAsync(account => account.Id == accountDto.Id);

                if (verifyAccountId || verifyAccountNumber)
                {
                    throw new Exception("This account already exist");
                }
                if (!userExist)
                {
                    throw new Exception("User not found");
                }

                var newAccount = new Account()
                {
                    AccountNumber = accountDto.AccountNumber,
                    Balance = 0.00M,
                    UserId = idUser
                };

                await this.context.Accounts.AddAsync(newAccount);
                await this.context.SaveChangesAsync();
                 
            response.Data = newAccount;
            response.Message = "Account created";
            response.Status = true;
            
            return response;
            }catch(Exception error)
            {
                response.Message = error.Message;
                response.Status = false;
                return response;
            }
        }
    }
}