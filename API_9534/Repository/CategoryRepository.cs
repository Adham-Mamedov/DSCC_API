using API_9534.DBContexts;
using API_9534.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_9534.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ProductContext _dbContext;
        public CategoryRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteCategory(int productId)
        {
            var product = _dbContext.Categories.Find(productId);
            _dbContext.Categories.Remove(product);
            Save();
        }
        public Category GetCategoryById(int productId = 1)
        {
            var cat = _dbContext.Categories.Find(productId);
            if (cat == null)
            {
                return null;
            }
            return cat;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }
        public void InsertCategory(Category product)
        {
            _dbContext.Add(product);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateCategory(Category product)
        {
            _dbContext.Entry(product).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
