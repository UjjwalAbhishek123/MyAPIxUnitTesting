
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //creating private field of IUserService class(which is implementing IUserService)
        //private readonly IUserService _userService;
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            //getting data from UserService
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        //[HttpGet]
        //public IActionResult GetAllUsers()
        //{
        //    //getting data from UserService
        //    var users = _userService.GetAllUsers();
        //    return Ok(users);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetUserById(int id)
        //{
        //    var user = _userService.GetUserById(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserByIdAsync), new { id = user.Id }, user);
        }

        //[HttpPost]
        //public IActionResult AddUser([FromBody] User user)
        //{
        //    _userService.AddUser(user);
        //    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateUser(int id, [FromBody] User user)
        //{
        //    if(id != user.Id)
        //    {
        //        return BadRequest();
        //    }
        //    _userService.UpdateUser(user);
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteUser(int id)
        //{
        //    _userService.DeleteUser(id);
        //    return NoContent();
        //}
    }
}
