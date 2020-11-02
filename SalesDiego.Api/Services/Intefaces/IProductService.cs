using System.Collections.Generic;
using SalesDiego.Api.Dtos;

namespace SalesDiego.Api.Services.Intefaces
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        int CreateProduct(CreateProductDto productDto);
        List<CategoryProductDto> GetCategoryProducts();
        List<ProductDto> GetProductsByCategoryProductName(string nameCategory);
        ProductDto GetProductById(int idProduct);
        int UpdateProduct(ProductDto productDto);
        int AddImageSecundaryOfProduct(ImageProductDto imageProduct);
        int DeleteImageSecundaryOfProduct(ImageProductDto imageProduct);
    }
}
