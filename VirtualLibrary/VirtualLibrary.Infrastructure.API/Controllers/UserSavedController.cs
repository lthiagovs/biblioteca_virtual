using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Infrastructure.API.Interfaces;

namespace VirtualLibrary.Infrastructure.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserSavedController : Controller
    {

        private readonly IUserSavedRepository _userSavedRepository;

        public UserSavedController(IUserSavedRepository userSavedRepository)
        {
            this._userSavedRepository = userSavedRepository;
        }

        [HttpGet("GetAllUserSavedBooks")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetAllUserSavedBooks([FromQuery]int ID)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = this._userSavedRepository.GetAllUserSavedBooks(ID);

            if (books == null)
                return BadRequest(ModelState);

            return Ok(books);

        }



        [HttpPost("UserSaveBook")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UserSaveBook([FromQuery]UserSaved saved)
        {

            if (saved == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._userSavedRepository.UserSaveBook(saved))
            {
                ModelState.AddModelError("", "Something went wrong while creating...");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created!");

        }

    }
}
