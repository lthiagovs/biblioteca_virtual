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

                var filesPath = Path.Combine(Directory.GetCurrentDirectory(), "files");

                if (!Directory.Exists(filesPath))
                    Directory.CreateDirectory(filesPath);

                var imagePath = Path.Combine(filesPath, bookImage.FileName);
                var filePath = Path.Combine(filesPath, bookFile.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await bookImage.CopyToAsync(stream);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await bookFile.CopyToAsync(stream);
                }

                Book book = new Book();

                // Verifica se o título ou a descrição estão nulos ou vazios
                if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Description))
                    return View(request);
                

                book.Title = request.Title;
                book.Description = request.Description;
                book.AuthorID = user.ID;
                book.CategoryID = 1;
                //book.Author = user;
                //book.Category = await this._categoryApiService.GetCategoryByID(1);

                await this._bookApiService.CreateBook(book);

                return RedirectToAction("Index");

            }



            return View();
        }

    }
}
