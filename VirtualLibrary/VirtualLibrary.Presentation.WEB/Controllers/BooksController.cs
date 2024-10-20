using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Presentation.WEB.Models;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBookApiService _bookApiService;
        private readonly ICategoryApiService _categoryApiService;
        private readonly IUserSavedApiService _userSavedApiService;

        public BooksController(IBookApiService bookApiService, ICategoryApiService categoryApiService, IUserSavedApiService userSavedApiService)
        {
            this._bookApiService = bookApiService;
            this._categoryApiService = categoryApiService;
            this._userSavedApiService = userSavedApiService;
        }

        public async Task<IActionResult> Index(string? title)
        {

            List<Book>? books;
            List<Category>? categories;

            try
            {

                if (title == null)
                    books = await this._bookApiService.GetAllBooks();
                else
                    books = await this._bookApiService.GetBooksByTitle(title);

                categories = await this._categoryApiService.GetAllCategories();

            }
            catch
            {
                books = null;
                categories = null;
            }

            TempData["Books"] = books;
            TempData["Categories"] = categories;

            return View();


        }

        public async Task<IActionResult> SaveBook([FromForm] BookRequestModel request)
        {

            if (request.ID == null)
                return RedirectToAction("Index", "Home");

            User? user = null;

            if (Request.Cookies.TryGetValue("UserCookie", out string? valor))
                if (valor != null)
                    user = JsonConvert.DeserializeObject<User>(valor);

            if (user == null)
                return RedirectToAction("Index", "Home");

            List<Book>? saveds = await this._userSavedApiService.GetAllUserSavedBooks(user.ID);

            int bookID = Convert.ToInt32(request.ID);

            if (saveds.Any(book => book.ID == bookID))
                return RedirectToAction("Index", "Home");

            UserSaved saved = new UserSaved();
            saved.BookID = bookID;
            saved.UserID = user.ID;

            await _userSavedApiService.UserSaveBook(saved);

            return RedirectToAction("Index", "User");
        }

        public IActionResult Search([FromForm] BookRequestModel request)
        {
            
            if(request.Title == null)
                return RedirectToAction("Index");

            return RedirectToAction("Index", new { title = request.Title });

        }

    }
}
