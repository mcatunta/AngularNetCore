using System.Collections.Generic;

namespace SalesDiego.Api.Dtos
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public int IdCategoryProduct { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string CategoryProductName { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public List<string> Images { get; set; }
        public ProductDto()
        {
            Images = new List<string>();
        }
    }
}
