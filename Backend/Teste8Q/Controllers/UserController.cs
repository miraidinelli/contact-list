using Microsoft.AspNetCore.Mvc;
using Teste8Q.Service.Interfaces;
using Teste8Q.Models;
using System.Runtime.CompilerServices;


namespace Teste8Q.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("user/id/{userId:int}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("The user was not found, verify if this is the correct id and try again");
            }
            return Ok(user);
        }

        [HttpGet("user/company/{company}")]
        public async Task<ActionResult<List<User>>> GetUserByCompany(string company)
        {
            var users = await _userService.GetUserByCompany(company);
            if (users == null || users.Count == 0)
            {
                return BadRequest("This company or user doesn't exist");
            }
            return Ok(users);
        }

        [HttpGet("user/personalNumber/{number}")]
        public async Task<ActionResult<User>> GetUserByPersonalNumber(string number)
        {
            var user = await _userService.GetUserByPersonalNumber(number);
            if (user == null)
            {
                return NotFound("No user found with this number");
            }
            return Ok(user);
        }

        [HttpGet("user/businessNumber/{number}")]
        public async Task<ActionResult<User>> GetUserByBusinessNumber(string number)
        {
            var user = await _userService.GetUserByBusinessNumber(number);
            if (user == null)
            {
                return NotFound("No user found with this number");
            }
            return Ok(user);
        }

        [HttpGet("user/email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound("No user found with the given email");
            }
            return Ok(user);
        }

        [HttpGet("user/name/{name}")]
        public async Task<ActionResult<List<User>>> GetUserByName(string name)
        {
            var users = await _userService.GetUserByName(name);
            if (users == null || users.Count == 0)
            {
                return NotFound("User not found");
            }
            return Ok(users);
        }

        [HttpDelete("user/id/{userId:int}")]
        public async Task<ActionResult<List<User>>> DeleteUserById(int id)
        {
            var result = await _userService.DeleteUserById(id);
            if (result == null)
                return NotFound("No user found by this id");
            return Ok(result);
        }
        [HttpPost("user/id")]
        public async Task<ActionResult<List<User>>> UpdateUser(User user, int id)
        {
            var request = await _userService.UpdateUser(user, id);
            if (request == null)
                return BadRequest("not able to complete the request");
            return Ok(request);
        }
    }


}
