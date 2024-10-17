using VirtualLibrary.Domain.Models.Library;

namespace VirtualLibrary.Infrastructure.API.Interfaces
{
    public interface ICategoryRepository
    {

        public ICollection<Category> GetAllCategories();

        public Category? GetCategoryByName(string name);

        public Category? GetCategoryByID(int ID);

        public bool CreateCategory(Category category);

        public bool UpdateCategory(Category category);

        public bool DeleteCategory(Category category);

    }

}
