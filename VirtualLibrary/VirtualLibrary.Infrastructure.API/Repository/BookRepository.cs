using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Infrastructure.API.Interfaces;
using VirtualLibrary.Infrastructure.Data.Context;

namespace VirtualLibrary.Infrastructure.API.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this._context.Book.ToList();
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return this._context.Book.Where(book => book.Title.Contains(title)).ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(int ID)
        {
            return this._context.Book.Where(book => book.AuthorID == ID).ToList();
        }

        public Book? GetBookByID(int ID)
        {
            return this._context.Book.FirstOrDefault(book => book.ID == ID);
        }

        public bool CreateBook(Book book)
        {
            this._context.Add(book);
            return this.Save();
        }

        public bool UpdateBook(Book book)
        {
            this._context.Update(book);
            return this.Save();
        }

        public bool DeleteBook(Book book)
        {
            this._context.Remove(book);
            return this.Save();
        }

        public bool Save()
        {
            int saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }

}
