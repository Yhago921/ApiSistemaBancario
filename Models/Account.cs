namespace  Api.Models
{
    public class Account
    {
       public int Id {get; set; }
       public string? AccountNumber {get; set;}
       public int UserId {get; set; }
       public decimal Balance {get; set;}
       public User? User {get; set;}

       public void DiminuirSaldo( decimal Amount)
        {
            if(Amount <= 0)
               throw new Exception("Invalid amount");

               if(Balance < Amount)
               throw new Exception("Insuficient Balance");

               Balance -= Amount;
        }   
       public void AumentarSaldo( decimal Amount)
        {
            if(Amount <= 0)
               throw new Exception("Invalid amount");
            Balance += Amount;
        }   
    }
}