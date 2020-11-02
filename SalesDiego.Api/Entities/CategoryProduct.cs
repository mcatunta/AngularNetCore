using System.Collections.Generic;

namespace SalesDiego.Api.Entities
{
    public class CategoryProduct
    {
        public int IdCategoryProduct { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        
        public CategoryProduct()
        {
            Products = new List<Product>();
        }

        public static CategoryProduct Create(string name)
        {
            return new CategoryProduct()
            {
                Name = name
            };
        }
    }
}
