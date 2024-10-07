using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Infrastructure.API.Interfaces
{
    public interface IUserRepository : IRepository
    {

        public IEnumerable<User> GetAllUsers();

        public User? GetUserByID(int ID);

        public User? GetUserByLogin(string email, string password);

        public User? GetUserByBook(Book book);

        public bool CreateUser(User user);

        public bool DeleteUser(User user);

        public bool UpdateUser(User user);


    }

}
