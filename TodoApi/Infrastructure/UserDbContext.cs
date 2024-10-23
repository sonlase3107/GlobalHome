using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Infrastructure;

public class UserDbContext : DbContext
{
    public UserDbContext()
    {
    }
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=Db1;User=sa;Password=Mubeo123@;Encrypt=True;TrustServerCertificate=True;");
    }
    public DbSet<User> Users { get; set; }
}
