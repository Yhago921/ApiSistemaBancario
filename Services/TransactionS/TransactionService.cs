using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.TransactionS
{
    public class TransactionService : ITransactionInterface
    {
        private readonly AppDBContext context;
        public TransactionService(AppDBContext context)
        {
            this.context = context;
        }
        public async Task<ResponseModel<Transaction>> Transfer(int FromAccountId, int ToAccountId, decimal Amount)
        {
            ResponseModel<Transaction> response = new();
            try
            {   
                var FromAccount = await this.context.Accounts.FirstOrDefaultAsync(a => a.Id == FromAccountId);
                var ToAccount = await this.context.Accounts.FirstOrDefaultAsync(a => a.Id == ToAccountId);

                if(FromAccountId == ToAccountId)
                throw new Exception("Não é possível fazer esta operação!");

                if (FromAccount == null)
                throw new Exception("Conta de origem não encontrada");

                if (ToAccount == null)
                throw new Exception("Conta de destino não encontrada");

                FromAccount.DiminuirSaldo(Amount);
                ToAccount.AumentarSaldo(Amount);
                
                var transaction = new Transaction()
                {
                    FromAccountId = FromAccount.Id,
                    ToAccountId = ToAccount.Id,
                    Amount = Amount,
                    Date = DateTime.Now,
                    Type = Models.Enums.TransactionType.Transfer
                };
                
                
                response.Data = transaction;
                response.Message = "Transferência feita com sucesso";
                response.Status = true;

                await this.context.Transactions.AddAsync(transaction);
                await this.context.SaveChangesAsync();

                return response;

            }catch(Exception error)
            {
       
{
    response.Message = error.Message;
    response.Status = false;
    return response;
}   
            }
        }
    }
}