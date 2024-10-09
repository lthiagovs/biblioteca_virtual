using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class UserController : Controller
    {


        public UserController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
