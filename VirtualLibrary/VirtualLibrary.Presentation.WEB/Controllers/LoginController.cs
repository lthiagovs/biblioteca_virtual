using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class LoginController : Controller
    {


        public LoginController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
