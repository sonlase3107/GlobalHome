
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

        await _userRepository.LoadAsBatch(users);
    }

}
