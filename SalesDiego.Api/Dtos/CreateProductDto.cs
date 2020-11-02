namespace SalesDiego.Api.Dtos
{
    public class CreateProductDto
    {
        public int IdCategoryProduct { get; set; }
        public string NameCategory { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int QuantityImages { get; set; }
    }
}
