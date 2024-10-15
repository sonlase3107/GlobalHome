
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TodoApi.DomainLogic;
using TodoApi.Extentions;
using TodoApi.Infrastructure;
using TodoApi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<UserDbContext>(options => 
//     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<UserDbContext>(options => 
    options.UseInMemoryDatabase("TodoList"));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserDomainService>();

var app = builder.Build();



// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseMiddleware<CustomMiddleware>();
app.MapControllers();

app.Run();
