using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options){}
        public DbSet<User> Users {get; set; }
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Transaction> Transactions {get; set; }
    }
}