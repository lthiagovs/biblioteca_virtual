using Microsoft.AspNetCore.Mvc;
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
