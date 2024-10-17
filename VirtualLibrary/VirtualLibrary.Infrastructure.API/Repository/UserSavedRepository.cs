using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Infrastructure.API.Interfaces;
using VirtualLibrary.Infrastructure.Data.Context;

namespace VirtualLibrary.Infrastructure.API.Repository
{
    public class UserSavedRepository : IUserSavedRepository
    {

        private readonly DataContext _context;

        public UserSavedRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<Book> GetAllUserSavedBooks(int ID)
        {
            List<Book> books = new List<Book>();
            foreach (UserSaved saved in this._context.UserSaved.Where(save => save.UserID == ID))
            {
                Book? book = this._context.Book.FirstOrDefault(bk => bk.ID == saved.BookID);

                if (book != null)
                    books.Add(book);

            }

            return books;

        }

        public bool UserSaveBook(UserSaved saved)
        {
            this._context.Add(saved);
            return this.Save();
        }

        public bool Save()
        {
            int saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }

}
