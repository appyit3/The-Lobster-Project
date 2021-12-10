using Lobster.API.Entities;
using Lobster.API.Repositories;
using Lobster.API.Models;
using Lobster.API.Services;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Lobster.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseRepository _repository;
        private IUserService _userService;

        public UserController(IDatabaseRepository repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var Users = await _repository.GetUsers();
            return Ok(Users);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "You are trying to hack the system :(#) Go away!" });

            return Ok(response);
        } 

        // [HttpGet("{id:length(24)}", Name = "GetUser")]
        // [ProducesResponseType((int)HttpStatusCode.NotFound)]
        // [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        // public async Task<ActionResult<User>> GetUserById(string id)
        // {
        //     var User = await _repository.GetUser(id);

        //     if (User == null)
        //     {
        //         _logger.LogError($"User with id: {id}, not found.");
        //         return NotFound();
        //     }

        //     return Ok(User);
        // }

        // [Route("[action]/{category}", Name = "GetUserByCategory")]
        // [HttpGet]
        // [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        // public async Task<ActionResult<IEnumerable<User>>> GetUserByCategory(string category)
        // {
        //     var Users = await _repository.GetUserByCategory(category);
        //     return Ok(Users);
        // }

        // [Route("[action]/{name}", Name = "GetUserByName")]
        // [HttpGet]
        // [ProducesResponseType((int)HttpStatusCode.NotFound)]
        // [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        // public async Task<ActionResult<IEnumerable<User>>> GetUserByName(string name)
        // {
        //     var items = await _repository.GetUserByName(name);
        //     if (items == null)
        //     {
        //         _logger.LogError($"Users with name: {name} not found.");
        //         return NotFound();
        //     }
        //     return Ok(items);
        // }

        // [HttpPost]
        // [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        // public async Task<ActionResult<User>> CreateUser([FromBody] User User)
        // {
        //     await _repository.CreateUser(User);

        //     return CreatedAtRoute("GetUser", new { id = User.Id }, User);
        // }

        // [HttpPut]
        // [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        // public async Task<IActionResult> UpdateUser([FromBody] User User)
        // {
        //     return Ok(await _repository.UpdateUser(User));
        // }

        // [HttpDelete("{id:length(24)}", Name = "DeleteUser")]        
        // [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        // public async Task<IActionResult> DeleteUserById(string id)
        // {
        //     return Ok(await _repository.DeleteUser(id));
        // }
    }
}
