using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Infrastructure.API.Interfaces;

namespace VirtualLibrary.Infrastructure.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpGet("GetAllCategories")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetAllCategories()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categories = this._categoryRepository.GetAllCategories();

            if (categories == null)
                return BadRequest(ModelState);

            return Ok(categories);

        }

        [HttpGet("GetCategoryByName")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult GetCategoryByName([FromQuery] string name)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = this._categoryRepository.GetCategoryByName(name);

            return Ok(category);

        }

        [HttpGet("GetCategoryByID")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult GetBooksByAuthor(int ID)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = this._categoryRepository.GetCategoryByID(ID);

            return Ok(category);

        }


        [HttpPost("CreateCategory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory(Category category)
        {

            if (category == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._categoryRepository.CreateCategory(category))
            {
                ModelState.AddModelError("", "Something went wrong while creating...");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created!");

        }

        [HttpPut("UpdateCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateCategory(Category category)
        {

            if (category == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._categoryRepository.UpdateCategory(category))
            {
                ModelState.AddModelError("", "Something went wrong while updating...");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("DeleteCategory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(Category category)
        {

            if (category == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._categoryRepository.DeleteCategory(category))
            {
                ModelState.AddModelError("", "Something went wrong while deleting...");
            }

            return NoContent();

        }

    }
}
