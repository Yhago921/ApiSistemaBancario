using Api.Data;
using Api.Services.AccountS;
using Api.Services.TransactionS;
using Api.Services.UserS;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddScoped<IUserInterface, UserService>();
    builder.Services.AddScoped<IAccountInterface, AccountService>();
    builder.Services.AddScoped<ITransactionInterface, TransactionService>();

    builder.Services.AddControllers();
    builder.Services.AddOpenApi();

    builder.Services.AddDbContext<AppDBContext>(options=> 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.MapGet("/", () => "Hello World");

app.Run();