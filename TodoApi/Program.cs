
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TodoApi.Extentions;
using TodoApi.Infrastructure;
using TodoApi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("Data Source = UnitTestDb.db")));
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseMiddleware<CustomMiddleware>();
app.MapControllers();

app.Run();
