using Microsoft.EntityFrameworkCore;
using SalesDiego.Api.Dtos;
using SalesDiego.Api.Entities;
using SalesDiego.Api.Repositories.Intefaces;
using SalesDiego.Api.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesDiego.Api.Services.Impl
{
    public class ProductService : IProductService
    {
        private IGenericRepository _genericRepository;
        public ProductService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public List<ProductDto> GetProducts()
        {
            var products = _genericRepository.GetAll<Product>()
                .Include(p => p.CategoryProduct)
                .Include(p => p.ImageProducts);
            return products.Select(p => new ProductDto()
            {
                IdProduct = p.IdProduct,
                IdCategoryProduct = p.IdCategoryProduct,
                CategoryProductName = p.CategoryProduct.Name,
                ProductName = p.Name,
                Description = p.Description,
                Price = p.Price.ToString(),
                Image = string.Format("{0}_{1}", p.IdProduct, p.Image),
                Images = p.ImageProducts.Where(q => q.Active).ToList().Count == 0 ? new List<string>()
                        : p.ImageProducts.Where(q => q.Active)
                        .Select(p => string.Format("{0}_{1}", p.IdProduct, p.Name)).ToList()
            }).ToList();
        }
        public int CreateProduct(CreateProductDto productDto)
        {
            CategoryProduct categoryProduct;            
            if (productDto.IdCategoryProduct == 0)
            {
                var myCategoryProduct = _genericRepository.Filter<CategoryProduct>
                    (p => p.Name == productDto.NameCategory.ToLower()).FirstOrDefault();
                categoryProduct = myCategoryProduct == null
                    ? CategoryProduct.Create(productDto.NameCategory) : myCategoryProduct;
            }
            else
                categoryProduct = _genericRepository.Filter<CategoryProduct>
                    (p => p.IdCategoryProduct == productDto.IdCategoryProduct).FirstOrDefault();
            
            var product = Product.Create(categoryProduct, productDto.NameProduct
                , productDto.Description, decimal.Parse(productDto.Price)); 
            
            for (var image=1; image<=productDto.QuantityImages; image++)
            {
                var imageProduct = ImageProduct.Create(image);
                product.ImageProducts.Add(imageProduct);
            }
            _genericRepository.Add(product);
            _genericRepository.SaveChanges();
            return product.IdProduct;
        }

        public List<CategoryProductDto> GetCategoryProducts()
        {
            var categoryProducts = _genericRepository.GetAll<CategoryProduct>().ToList();
            return categoryProducts.Select(p => new CategoryProductDto()
            {
                IdCategoryProduct = p.IdCategoryProduct,
                Name = p.Name
            }).ToList();
        }

        public List<ProductDto> GetProductsByCategoryProductName(string nameCategory)
        {
            var products = _genericRepository
                .Filter<Product>(p => p.CategoryProduct.Name == nameCategory.ToLower())
                .Include(p => p.CategoryProduct)
                .Include(p => p.ImageProducts);
            return products.Select(p => new ProductDto()
            {
                IdProduct = p.IdProduct,
                IdCategoryProduct = p.IdCategoryProduct,
                CategoryProductName = p.CategoryProduct.Name,
                ProductName = p.Name,
                Description = p.Description,
                Price = p.Price.ToString(),
                Image = string.Format("{0}_{1}", p.IdProduct, p.Image),
                Images = p.ImageProducts.Where(q => q.Active).ToList().Count == 0 ? new List<string>()
                        : p.ImageProducts.Where(q => q.Active)
                        .Select(p => string.Format("{0}_{1}", p.IdProduct, p.Name)).ToList()
            }).ToList();
        }

        public ProductDto GetProductById(int idProduct)
        {
            var product = _genericRepository.Filter<Product>(p => p.IdProduct == idProduct)
                .Include(p => p.CategoryProduct)
                .Include(p => p.ImageProducts)
                .FirstOrDefault();
            if (product == null)
                throw new ApplicationException(string.Format("No existe el producto con código {0}", idProduct));
            return new ProductDto()
            {
                IdProduct = product.IdProduct,
                IdCategoryProduct = product.IdCategoryProduct,
                CategoryProductName = product.CategoryProduct.Name,
                ProductName = product.Name,
                Description = product.Description,
                Price = product.Price.ToString(),
                Image = string.Format("{0}_{1}", product.IdProduct, product.Image),
                Images = product.ImageProducts.Where(q => q.Active).ToList().Count == 0 ? new List<string>()
                    : product.ImageProducts.Where(q => q.Active)
                    .Select(p => string.Format("{0}_{1}", p.IdProduct, p.Name)).ToList()
            };
        }

        public int UpdateProduct(ProductDto productDto)
        {
            var product = _genericRepository.Filter<Product>(p => p.IdProduct == productDto.IdProduct)
                .Include(p => p.CategoryProduct)
                .FirstOrDefault();
            CategoryProduct categoryProduct;
            if (productDto.IdCategoryProduct == 0)
            {
                var myCategoryProduct = _genericRepository.Filter<CategoryProduct>
                    (p => p.Name == productDto.CategoryProductName.ToLower()).FirstOrDefault();
                categoryProduct = myCategoryProduct == null
                    ? CategoryProduct.Create(productDto.CategoryProductName) : myCategoryProduct;
            }
            else
                categoryProduct = _genericRepository.Filter<CategoryProduct>
                    (p => p.IdCategoryProduct == productDto.IdCategoryProduct).FirstOrDefault();
            product.Update(categoryProduct, productDto.ProductName, productDto.Description
                , decimal.Parse(productDto.Price));
            _genericRepository.SaveChanges();
            return productDto.IdProduct;
        }

        public int AddImageSecundaryOfProduct(ImageProductDto imageProductDto)
        {
            var imageProducts = _genericRepository.Filter<ImageProduct>
                (p => p.IdProduct == imageProductDto.IdProduct).ToList();
            var newImageName = imageProducts.Count() + 1;
            var newImageProduct = ImageProduct.Create(imageProductDto.IdProduct, newImageName);
            _genericRepository.Add(newImageProduct);
            _genericRepository.SaveChanges();
            return newImageName;
        }

        public int DeleteImageSecundaryOfProduct(ImageProductDto imageProductDto)
        {
            var imageProduct = _genericRepository.Filter<ImageProduct>
                (p => p.Name == imageProductDto.ImageName
                && p.IdProduct == imageProductDto.IdProduct && p.Active).FirstOrDefault();
            if (imageProduct == null)
                throw new ApplicationException(string.Format("Image {0}_{1} no encontrada"
                    , imageProductDto.IdProduct, imageProductDto.ImageName));
            imageProduct.Desactive();
            _genericRepository.SaveChanges();
            return imageProductDto.ImageName;
        }
    }
}
