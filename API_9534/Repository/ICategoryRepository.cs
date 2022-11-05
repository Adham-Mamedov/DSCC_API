using API_9534.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_9534.Repository
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
        Category GetCategoryById(int Id);
        IEnumerable<Category> GetCategories();
    }
}
