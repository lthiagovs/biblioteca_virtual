using Microsoft.AspNetCore.Mvc;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Presentation.WEB.Models;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBookApiService _bookApiService;

        public BooksController(IBookApiService bookApiService)
        {
            this._bookApiService = bookApiService;
        }

        public async Task<IActionResult> Index(string? title)
        {

            List<Book>? books = null;
            try
            {

                if (title == null)
                    books = await this._bookApiService.GetAllBooks();
                else
                    books = await this._bookApiService.GetBooksByTitle(title);

            }
            catch
            {
            }

            TempData["Books"] = books;

            return View();


        }

        public IActionResult Search([FromForm] BookFilterModel request)
        {
            
            if(request.Title == null)
                return RedirectToAction("Index");

            return RedirectToAction("Index", new { title = request.Title });

        }

    }
}
