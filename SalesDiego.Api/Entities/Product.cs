using System.Collections.Generic;

namespace SalesDiego.Api.Entities
{
    public class Product
    {
        public int IdProduct { get; set; }
        public int IdCategoryProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Image { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
        public List<ImageProduct> ImageProducts { get; set; }
        public List<DetailOrder> DetailOrders { get; set; }

        public Product()
        {
            ImageProducts = new List<ImageProduct>();
            DetailOrders = new List<DetailOrder>();
        }

        public static Product Create(CategoryProduct categoryProduct, string name
            , string description, decimal price)
        {
            return new Product()
            {
                Name = name,
                Description = description,
                Price = price,
                Image = 0,
                CategoryProduct = categoryProduct
            };
        }

        public void Update(CategoryProduct categoryProduct, string name, string description
            , decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryProduct = categoryProduct;
        }
    }
}
