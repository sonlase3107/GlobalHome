using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;
        public UserController(IUserRepository userRepository)
        {
            _userService = userRepository;
        }

        [HttpGet(Name = "/GetAllUser")]
        public async Task<IActionResult> GetAllSync()
        {
            var lstUser = await _userService.GetAllAsync();
            return Ok(lstUser);
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO userRequestDTO)
        {
            Console.WriteLine($"Log: Start Jere");
            if (userRequestDTO != null)
            {
                Console.WriteLine($"Log: {userRequestDTO}");
                User user = new User()
                {
                    Id = userRequestDTO.Id,
                    Name = userRequestDTO.Name,
                    Email = userRequestDTO.Email,
                };
                var result = await _userService.CreateAsync(user);
                return Ok(result);
            }
            return BadRequest("Fail rồi");
        }
    }
}
