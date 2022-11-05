using API_9534.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_9534.DBContexts
{
    public class CategoryContext: DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) { }
        public DbSet<Category> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
