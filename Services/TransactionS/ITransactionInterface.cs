using Api.Models;
using Azure;

namespace Api.Services.TransactionS
{
    public interface ITransactionInterface
    {
        Task<ResponseModel<Transaction>> Transfer(int FromAccountId, int ToAccountId, decimal Amount);
    }
}