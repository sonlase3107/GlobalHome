using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DomainLogic;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDomainService _userDomainService;
        public UserController(UserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        [HttpPost(Name = "LoadToDb")]
        public async Task<IActionResult> GetAllSync([FromBody] IEnumerable<UserRequestDTO> userRequestDTOs)
        {

            var lstUsers = new List<User>();
            userRequestDTOs.ToList().ForEach(userRequestDTO =>
            {
                Debug.WriteLine($"{userRequestDTO.ToString()}");

            });
            _userDomainService.LoadDataToUser(lstUsers);
            return Ok("Oke");
        }
    }
}
