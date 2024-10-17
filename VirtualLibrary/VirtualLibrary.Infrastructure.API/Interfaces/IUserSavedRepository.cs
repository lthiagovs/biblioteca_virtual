using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Infrastructure.API.Interfaces
{
    public interface IUserSavedRepository : IRepository
    {

        public ICollection<Book> GetAllUserSavedBooks(int ID);

        public bool UserSaveBook(UserSaved saved);


    }

}
