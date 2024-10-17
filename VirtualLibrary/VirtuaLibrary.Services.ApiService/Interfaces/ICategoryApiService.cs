using VirtualLibrary.Domain.Models.Library;

namespace VirtuaLibrary.Services.ApiService.Interfaces
{
    public interface ICategoryApiService
    {

        public Task<List<Category>> GetAllCategories();

        public Task<Category?> GetCategoryByName(string name);

        public Task<Category?> GetCategoryByID(int ID);

        public Task<bool> CreateCategory(Category category);

        public Task<bool> UpdateCategory(Category category);

        public Task<bool> DeleteCategory(Category category);

    }

}
