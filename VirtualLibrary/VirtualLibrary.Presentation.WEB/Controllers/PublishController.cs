using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class PublishController : Controller
    {


        public PublishController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
