using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_9534.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
