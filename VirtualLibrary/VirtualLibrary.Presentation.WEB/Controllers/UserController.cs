using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Presentation.WEB.Models;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserSavedApiService _userSavedApiService;
        private readonly IBookApiService _bookApiService;

        public UserController(IUserSavedApiService userSavedApiService, IBookApiService bookApiService)
        {
            this._userSavedApiService = userSavedApiService;
            this._bookApiService = bookApiService;
        }

        public async Task<IActionResult> Index()
        {

            User? user = null;

            if (Request.Cookies.TryGetValue("UserCookie", out string? valor))
                if(valor != null)       
                    user = JsonConvert.DeserializeObject<User>(valor);

            if (user == null)
                return RedirectToAction("Index", "Login");

            List<Book> books = await this._userSavedApiService.GetAllUserSavedBooks(user.ID);

            TempData["User"] = user;
            TempData["Books"] = books;

            return View();

        }

        public IActionResult Logout()
        {

            Response.Cookies.Delete("UserCookie");

            return RedirectToAction("Index", "Login");
        }

        public async Task<IActionResult> Download([FromForm] BookRequestModel request)
        {

            if (request.ID == null)
                return RedirectToAction("Index", "Home");

            int bookID = Convert.ToInt32(request.ID);

            Book? book = await this._bookApiService.GetBookByID(bookID);

            if (book == null)
                return RedirectToAction("Index", "Home");

            var filesPath = Path.Combine(Directory.GetCurrentDirectory(), "files");

            if (!Directory.Exists(filesPath))
                Directory.CreateDirectory(filesPath);

            string filePath = book.AuthorID + book.Title + ".pdf";

            filePath = Path.Combine(filesPath, filePath);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "application/pdf", book.Title+".pdf");

        }

        public async Task<IActionResult> Remove([FromForm] BookRequestModel request)
        {

        }


    }
}
