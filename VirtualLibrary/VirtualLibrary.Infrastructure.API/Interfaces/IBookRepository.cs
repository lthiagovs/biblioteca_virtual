using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Infrastructure.API.Interfaces
{
    public interface IBookRepository : IRepository
    {

        public IEnumerable<Book> GetAllBooks();

        public IEnumerable<Book> GetBooksByTitle(string title);

        public IEnumerable<Book> GetBooksByAuthor(int ID);

        public Book? GetBookByID(int ID);

        public bool CreateBook(Book book);

        public bool UpdateBook(Book book);

        public bool DeleteBook(Book book);

    }

}
