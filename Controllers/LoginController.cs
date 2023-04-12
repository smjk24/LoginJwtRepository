using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Login.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserServiceRepository _userServiceRepository;
        public LoginController(IUserServiceRepository userServiceRepository)
        {
            _userServiceRepository = userServiceRepository;
        }
        [HttpPost("sign")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userServiceRepository.Authenticate(username, password);
            if (user.IsSuccess)
                return Ok(new { Token = user.Token });
            //if (user.GetType().GetProperty("isSuccess").GetValue(user, null).ToString().ToLower()=="true")
            //    return Ok(new {Token = user.GetType().GetProperty("Token").GetValue(user, null).ToString()});
            return Unauthorized();
        }
        [HttpGet("getuser")]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            var userId = int.Parse(User.Identity.Name);
            var user = await _userServiceRepository.GetUserById(userId);
            return Ok(user);
        }
    }
}
