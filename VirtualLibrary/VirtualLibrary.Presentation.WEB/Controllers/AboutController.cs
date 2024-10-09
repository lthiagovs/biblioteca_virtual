using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class AboutController : Controller
    {


        public AboutController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
