using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/users")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("api/users")]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userService.AddUser(user);
            return Ok(user);
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            user.Id = id;
            _userService.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}