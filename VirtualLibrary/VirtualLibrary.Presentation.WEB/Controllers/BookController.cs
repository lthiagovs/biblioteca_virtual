using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class BookController : Controller
    {


        public BookController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
