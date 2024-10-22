using System;
using TodoApi.Models;

namespace TodoApi.Repository;

public interface IUserRepository
{

    Task<int> LoadAsBatch(IEnumerable<User> users);
    Task<bool> CreateAsync(User user);
    Task<User> GetUserByIdAsync(Guid id);

    Task<IEnumerable<User>> GetAllAsync();

    Task<bool> UpdateAsync(User user);

    Task<bool> DeleteAsync(int id);

}
