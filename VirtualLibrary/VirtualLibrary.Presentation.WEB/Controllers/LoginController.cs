using Microsoft.AspNetCore.Mvc;
using VirtuaLibrary.Services.ApiService.Interfaces;
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
            return View();
        }

        public IActionResult Login([FromForm] LoginRequestModel request)
        {

            if (request.email == null || request.password == null)
                return Index();

            var user = this._userService.GetUserByLogin(request.email, request.password);

            if (user == null)
                return Index();

            return RedirectToAction("Index", "User");

        }


    }
}
