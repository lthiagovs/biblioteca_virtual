using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Dto.Person;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Infrastructure.API.Interfaces;
using VirtualLibrary.Infrastructure.API.Mapper;

namespace VirtualLibrary.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet("GetUserByID")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserByID([FromBody] int ID)
        {

            if (!this._userRepository.UserExists(ID))
                return BadRequest(ModelState);

            var user = this._userRepository.GetUserByID(ID);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);

        }

        [HttpGet("GetUserByLogin")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserByLogin([FromQuery] string email, [FromQuery] string password)
        {

            var user = this._userRepository.GetUserByLogin(email, password);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);

        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] User user)
        {

            if (user == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var userMap = this._mapper.Map<User>(user);

            if(!_userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while creating...");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully Created!");

        }

        [HttpPut("UpdateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser([FromBody] User user)
        {

            if (user == null)
                return BadRequest(ModelState);

            if (!this._userRepository.UserExists(user.ID))
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while updating...");
                return StatusCode(500, ModelState);

            }

            return NoContent();

        }

        [HttpDelete("DeleteUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser([FromBody] User user)
        {

            if (!_userRepository.UserExists(user.ID))
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_userRepository.DeleteUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
            }

            return NoContent();

        }


    }
}
