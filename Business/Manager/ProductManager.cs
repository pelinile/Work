using Business.Dtos;
using Business.Services;
using Business.Types;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly ICategoryService _categoryService;

        public ProductManager(IRepository<ProductEntity> productRepository, ICategoryService categoryService)

        {
            _productRepository = productRepository;
            _categoryService = categoryService;
        }

        public ServiceMessage AddProduct(AddProductDto addProductDto)
        {

            var productEntity = new ProductEntity()
            {
                Name = addProductDto.Name,
                Description = addProductDto.Description,
                UnitInStock = addProductDto.UnitInStock,
                UnitPrice = addProductDto.UnitPrice,
                CategoryId = addProductDto.CategoryId,
                
            };

            _productRepository.Add(productEntity);

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public EditProductDto GetProductById(int id)
        {
            var productEntity = _productRepository.GetById(id);

            var editProductDto = new EditProductDto()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Description = productEntity.Description,
                UnitInStock = productEntity.UnitInStock,
                UnitPrice = productEntity.UnitPrice,
                CategoryId = productEntity.CategoryId
            };

            return editProductDto;
        }

        public List<ProductDto> GetProducts()
        {
            var productEntites = _productRepository.GetAll().OrderBy(x => x.Category.Name).ThenBy(x => x.Name);

            var productDtoList = productEntites.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                UnitInStock = x.UnitInStock,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
            }).ToList();

            return productDtoList;
        }

        public List<ProductDto> GetProductsByCategoryId(int? categoryId = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(EditProductDto editProductDto)
        {
            var productEntity = _productRepository.GetById(editProductDto.Id);

            productEntity.Name = editProductDto.Name;
            productEntity.Description = editProductDto.Description;
            productEntity.UnitInStock = editProductDto.UnitInStock;
            productEntity.UnitPrice = editProductDto.UnitPrice;
            productEntity.CategoryId = editProductDto.CategoryId;

            _productRepository.Update(productEntity);
        }

        
    }
}
