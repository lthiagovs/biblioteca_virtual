using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class BooksController : Controller
    {


        public BooksController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }




    }
}
