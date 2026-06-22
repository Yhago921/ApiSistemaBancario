using Api.Models.Enums;

namespace Api.Models
{

    public class Transaction
    {
    public int Id {get; set; }
    public int FromAccountId {get; set;}
    public int ToAccountId {get; set;}
    public decimal Amount {get; set;}
    public TransactionType Type {get; set;}
    public DateTime Date {get; set;}   
    }
}