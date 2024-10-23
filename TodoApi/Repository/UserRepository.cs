using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApi.Infrastructure;
using TodoApi.Models;

namespace TodoApi.Repository;

public class UserRepository(UserDbContext context) : IUserRepository
{
    public async Task<bool> CreateAsync(User user)
    {
        context!.Users.Add(user);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        context.Remove(id);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id) => await context.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<int> LoadAsBatch(IEnumerable<User> users)
    {
        await context.AddRange(users);
        return await context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(User user)
    {
        await context.Users.Where(x => x.Id == user.Id)
            .ExecuteUpdateAsync(setters => setters.
            SetProperty(b => b.Id, user.Id)
            .SetProperty(b => b.Name, user.Name)
            .SetProperty(b => b.Email, user.Email));
        return true;
    }
}
