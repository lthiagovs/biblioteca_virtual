using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserSavedApiService _userSavedApiService;

        public UserController(IUserSavedApiService userSavedApiService)
        {
            this._userSavedApiService = userSavedApiService;
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


    }
}
