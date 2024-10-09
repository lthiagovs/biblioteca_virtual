using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class ProfileController : Controller
    {


        public ProfileController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
