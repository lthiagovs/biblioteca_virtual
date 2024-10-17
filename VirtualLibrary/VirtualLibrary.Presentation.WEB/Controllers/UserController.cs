using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class UserController : Controller
    {


        public UserController()
        {
            
        }

        public IActionResult Index()
        {

            User? user = null;

            if (Request.Cookies.TryGetValue("UserCookie", out string? valor))                
                user = JsonConvert.DeserializeObject<User>(valor);

            if (user == null)
                return RedirectToAction("Index", "Login");

            TempData["User"] = user;

            return View();

        }

        public IActionResult Logout()
        {

            Response.Cookies.Delete("UserCookie");

            return RedirectToAction("Index", "Login");
        }


    }
}
