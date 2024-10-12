using VirtualLibrary.Domain.Models.Person;

namespace VirtuaLibrary.Services.ApiService.Interface
{
    public interface IUserUserApiService
    {

        public Task<List<User>> GetUsers();

        public Task<User?> GetUserByID(int ID);

        public Task<User?> GetUserByLogin(string email, string password);

        public Task<bool> UserExist(int ID);

        public Task<bool> CreateUser(User user);

        public Task<bool> UpdateUser(User user);

        public Task<bool> DeleteUser(User user);

    }

}
