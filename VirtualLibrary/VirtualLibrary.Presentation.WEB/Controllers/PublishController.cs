using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Presentation.WEB.Models;

namespace VirtualLibrary.Presentation.WEB.Controllers
{
    public class PublishController : Controller
    {

        private readonly IBookApiService _bookApiService;
        private readonly ICategoryApiService _categoryApiService;

        public PublishController(IBookApiService bookApiService, ICategoryApiService categoryApiService)
        {
            this._bookApiService = bookApiService;
            this._categoryApiService = categoryApiService;
        }

        public IActionResult Index()
        {

            User? user = null;

            if (Request.Cookies.TryGetValue("UserCookie", out string? valor))
                if (valor != null)
                    user = JsonConvert.DeserializeObject<User>(valor);

            if (user == null)
                return RedirectToAction("Index", "Login");

            TempData["User"] = user;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Publish(IFormFile bookImage, IFormFile bookFile, [FromForm]PublishModel request)
        {

            User? user = null;

            if (Request.Cookies.TryGetValue("UserCookie", out string? valor))
                if (valor != null)
                    user = JsonConvert.DeserializeObject<User>(valor);

            if (user == null)
                return RedirectToAction("Index", "Login");

            if (bookImage != null && bookFile != null)
            {

                var filesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

                if (!Directory.Exists(filesPath))
                    Directory.CreateDirectory(filesPath);

                Book book = new Book();

                // Verifica se o título ou a descrição estão nulos ou vazios
                if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Description))
                    return View(request);
                

                book.Title = request.Title;
                book.Description = request.Description;
                book.AuthorID = user.ID;
                book.CategoryID = 1;

                await this._bookApiService.CreateBook(book);

                var imageExtension = Path.GetExtension(bookImage.FileName);
                var bookExtension = Path.GetExtension(bookFile.FileName);

                var imagePath = Path.Combine(filesPath, (book.AuthorID+book.Title)+imageExtension);
                var filePath = Path.Combine(filesPath, (book.AuthorID + book.Title)+bookExtension);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await bookImage.CopyToAsync(stream);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await bookFile.CopyToAsync(stream);
                }

                return RedirectToAction("Index");

            }

            return View();
        }

    }
}
