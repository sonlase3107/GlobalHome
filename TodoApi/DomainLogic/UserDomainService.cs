
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.DomainLogic;

public class UserDomainService
{
    private readonly IUserRepository _userRepository;
    public UserDomainService(IUserRepository userRepository) {
        _userRepository = userRepository;
     }

    public async void LoadDataToUser(IEnumerable<User> users)
    {
        var usersWithIdtStartFrom0 = users.Where(x => x.Id >= 0).ToList();
        var usersWithIdtStartFrom5 = users.Where(x => x.Id >= 5).ToList();
        Console.WriteLine($"");

        await _userRepository.LoadAsBatch(usersWithIdtStartFrom0);
        await _userRepository.LoadAsBatch(usersWithIdtStartFrom5);
    }

}
