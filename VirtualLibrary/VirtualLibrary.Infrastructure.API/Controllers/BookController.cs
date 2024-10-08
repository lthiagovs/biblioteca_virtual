﻿using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Infrastructure.API.Interfaces;

namespace VirtualLibrary.Infrastructure.API.Controllers
{

    [ApiController]
    public class BookController : Controller
    {

        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("GetAllBooks")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllBooks()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = _bookRepository.GetAllBooks();

            if (books == null)
                return BadRequest(ModelState);

            return Ok(books);

        }

        [HttpGet("GetBooksByTitle")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooksByTitle([FromBody] string title)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = _bookRepository.GetBooksByTitle(title);

            if (books == null)
                return BadRequest(ModelState);

            return Ok(books);

        }

        [HttpGet("GetBooksByAuthor")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooksByAuthor([FromBody] User author)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = _bookRepository.GetBooksByAuthor(author);

            if (books == null)
                return BadRequest(ModelState);

            return Ok(books);

        }


        [HttpGet("GetBookByID")]
        [ProducesResponseType(400, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBookByID([FromBody] int ID)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = this._bookRepository.GetBookByID(ID);

            if(book == null)
                return BadRequest(book);

            return Ok(book);

        }

        [HttpPost("CreateBook")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBook([FromBody] Book book)
        {

            if (book == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._bookRepository.CreateBook(book))
            {
                ModelState.AddModelError("", "Something went wrong while creating...");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created!");

        }

        [HttpPut("UpdateBook")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateBook([FromBody] Book book)
        {

            if (book == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._bookRepository.UpdateBook(book))
            {
                ModelState.AddModelError("", "Something went wrong while updating...");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("DeleteBook")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook([FromBody]Book book)
        {

            if (book == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._bookRepository.DeleteBook(book))
            {
                ModelState.AddModelError("", "Something went wrong while deleting...");
            }

            return NoContent();

        }

    }
}
