namespace SalesDiego.Api.Entities
{
    public class ImageProduct
    {
        public int IdImageProduct { get; set; }
        public int IdProduct { get; set; }
        public int Name { get; set; }
        public bool Active { get; set; }
        public Product Product { get; set; }

        public static ImageProduct Create(int name)
        {
            return new ImageProduct()
            {
                Name = name,
                Active = true
            };
        }

        public static ImageProduct Create(int idProduct, int name)
        {
            return new ImageProduct()
            {
                IdProduct = idProduct,
                Name = name,
                Active = true
            };
        }

        public void Desactive()
        {
            Active = false;
        }
    }    
}
