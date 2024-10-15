using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtuaLibrary.Services.ApiService.Interfaces
{
    public interface IBookApiService
    {

        public Task<List<Book>> GetAllBooks();

        public Task<List<Book>> GetBooksByTitle(string title);

        public Task<List<Book>> GetBooksByAuthor(int ID);

        public Task<Book?> GetBookByID(int ID);

        public Task<bool> CreateBook(Book book);

        public Task<bool> UpdateBook(Book book);

        public Task<bool> DeleteBook(Book book);

    }

}
