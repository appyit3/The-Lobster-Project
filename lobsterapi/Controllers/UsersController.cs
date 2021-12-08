using Microsoft.AspNetCore.Mvc;
using Lobsterapi.Models;
using Lobsterapi.Services;
using System.Threading.Tasks;

namespace Lobsterapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "You are trying to hack the system :(#) Go away!" });

            return Ok(response);
        }

        // [Authorize]
        // [HttpGet]
        // public IActionResult GetAll()
        // {
        //     var users = _userService.GetAll();
        //     return Ok(users);
        // }
    }
}
