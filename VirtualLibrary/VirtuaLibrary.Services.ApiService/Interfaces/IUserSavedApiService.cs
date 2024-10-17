using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtuaLibrary.Services.ApiService.Interfaces
{
    public interface IUserSavedApiService
    {

        public Task<List<Book>> GetAllUserSavedBooks(int ID);

        public Task<bool> UserSaveBook(UserSaved saved);

    }

}
