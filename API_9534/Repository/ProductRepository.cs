using System;
using System.Collections.Generic;
using System.Linq;
using API_9534.DBContexts;
using API_9534.Model;
using Microsoft.EntityFrameworkCore;

namespace API_9534.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }
        public Product GetProductById(int productId = 1)
        {
            var prod = _dbContext.Products.Find(productId);
            if(prod == null)
            {
                return null;
            }
            _dbContext.Entry(prod).Reference(s => s.ProductCategory).Load();
            return prod;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.Include(s => s.ProductCategory).ToList();
        }
        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
