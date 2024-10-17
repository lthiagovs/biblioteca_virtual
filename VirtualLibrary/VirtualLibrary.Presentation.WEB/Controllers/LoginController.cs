using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Presentation.WEB.Models;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserApiService _userService;

        public LoginController(IUserApiService userService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {

            User? user = null;

            if (Request.Cookies.TryGetValue("UserCookie", out string? valor))
                user = JsonConvert.DeserializeObject<User>(valor);

            if (user != null)
                return RedirectToAction("Index", "User");

            return View();
        }

        [HttpPost]


        public async Task<IActionResult> Login([FromForm] LoginRequestModel request)        {

            if (request.email == null || request.password == null)
                return Index();

            User? user = null;
            try
            {
                user = await this._userService.GetUserByLogin(request.email, request.password);
                Response.Cookies.Append("UserCookie", JsonConvert.SerializeObject(user), new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1) // Define a expiração do cookie
                });
            }
            catch
            {
                TempData["Message"] = "Wrong credentials";
            }

            if (user == null)
                return RedirectToAction("Index");

            return RedirectToAction("Index", "User");

        }


    }
}
