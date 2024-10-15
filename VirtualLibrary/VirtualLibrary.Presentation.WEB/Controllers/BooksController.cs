using Microsoft.AspNetCore.Mvc;
using VirtuaLibrary.Services.ApiService.Interfaces;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBookApiService _bookApiService;

        public BooksController(IBookApiService bookApiService)
        {
            this._bookApiService = bookApiService;
        }

        public IActionResult Index()
        {

            var books = this._bookApiService.GetAllBooks();

            TempData["Books"] = books;

            return View();

        }




    }
}
