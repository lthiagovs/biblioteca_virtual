using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class HomeController : Controller
    {


        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
