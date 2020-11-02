using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SalesDiego.Api.Commons;
using SalesDiego.Api.Dtos;
using SalesDiego.Api.Services.Intefaces;
using System.Security.Permissions;

namespace SalesDiego.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = Security.Roles.ADMIN)]
        [Route("create-product")]
        public ActionResult<int> CreateProduct(CreateProductDto productDto)
        {
            return Execute(() =>
            {
                return _productService.CreateProduct(productDto);
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product")]
        public ActionResult<List<ProductDto>> GetProducts()
        {
            return Execute(() =>
            {
                return _productService.GetProducts();
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("category-products")]
        public ActionResult<List<CategoryProductDto>> GetCategoryProducts()
        {
            return Execute(() =>
            {
                return _productService.GetCategoryProducts();
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("products-by-category-name/{categoryName}")]
        public ActionResult<List<ProductDto>> GetProductsByCategoryProductName(string categoryName)
        {
            return Execute(() =>
            {
                return _productService.GetProductsByCategoryProductName(categoryName);
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/{idProduct}")]
        public ActionResult<ProductDto> GetProductById(int idProduct)
        {
            return Execute(() =>
            {
                return _productService.GetProductById(idProduct);
            });
        }

        [HttpPost]
        [Authorize(Roles = Security.Roles.ADMIN)]
        [Route("update-product/")]
        public ActionResult<int> UpdateProduct(ProductDto productDto)
        {
            return Execute(() =>
            {
                return _productService.UpdateProduct(productDto);
            });
        }

        [HttpPost]
        [Authorize(Roles = Security.Roles.ADMIN)]
        [Route("add-secundary-image")]
        public ActionResult<int> AddImageSecundaryOfProduct(ImageProductDto imageProduct)
        {
            return Execute(() =>
            {
                return _productService.AddImageSecundaryOfProduct(imageProduct);
            });
        }

        [HttpPost]
        [Authorize(Roles = Security.Roles.ADMIN)]
        [Route("delete-secundary-image")]
        public ActionResult<int> DeleteImageSecundary(ImageProductDto imageProduct)
        {
            return Execute(() =>
            {
                return _productService.DeleteImageSecundaryOfProduct(imageProduct);
            });
        }
    }
}
