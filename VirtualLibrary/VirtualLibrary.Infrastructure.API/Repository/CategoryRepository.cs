using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Infrastructure.API.Interfaces;
using VirtualLibrary.Infrastructure.Data.Context;

namespace VirtualLibrary.Infrastructure.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<Category> GetAllCategories()
        {
            return this._context.Category.ToList();
        }

        public Category? GetCategoryByName(string name)
        {
            return this._context.Category.FirstOrDefault(category => category.Name == name);
        }

        public Category? GetCategoryByID(int ID)
        {
            return this._context.Category.FirstOrDefault(category => category.ID == ID);
        }

        public bool CreateCategory(Category category)
        {
            this._context.Add(category);
            return this.Save();
        }

        public bool UpdateCategory(Category category)
        {
            this._context.Update(category);
            return this.Save();
        }

        public bool DeleteCategory(Category category)
        {
            this._context.Remove(category);
            return this.Save();
        }

        public bool Save()
        {
            int saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }

}
