using VirtualLibrary.Domain.Models.Person;
using VirtualLibrary.Infrastructure.API.Interfaces;
using VirtualLibrary.Infrastructure.Data.Context;

namespace VirtualLibrary.Infrastructure.API.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this._context.User.ToList();
        }

        public User? GetUserByID(int ID)
        {
            return this._context.User.FirstOrDefault(user => user.ID == ID);
        }

        public User? GetUserByLogin(string email, string password)
        {
            return this._context.User.FirstOrDefault(user => user.Email == email && user.Password == password);
        }

        public bool UserExists(int ID)
        {
            return this._context.User.Any(user => user.ID == ID);
        }

        public bool CreateUser(User user)
        {
            this._context.Add(user);
            return this.Save();
        }

        public bool DeleteUser(User user)
        {
            this._context.Remove(user);
            return this.Save();
        }

        public bool UpdateUser(User user)
        {
            this._context.Update(user);
            return this.Save();
        }

        public bool Save()
        {
            int saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }

}
