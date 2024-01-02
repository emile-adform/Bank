using Bank.WebApi.Middlewares;
using Bank.WebApi.Repositories;
using Bank.WebApi.Services;
using DbUp;
using Npgsql;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");
builder.Services.AddTransient<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));

var upgrader = DeployChanges.To
        .PostgresqlDatabase(dbConnectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();

EnsureDatabase.For.PostgresqlDatabase(dbConnectionString);

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    // Log or handle the error appropriately
    Console.WriteLine("Database migration failed: " + result.Error);
}

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<UserRepository>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
