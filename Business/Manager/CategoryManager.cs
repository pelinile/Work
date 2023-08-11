﻿using Business.Dtos;
using Business.Services;
using Business.Types;
using Data.Interfaces;
using Entities.Concrete;


namespace Business.Manager
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        public CategoryManager(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceMessage AddCategory(AddCategoryDto addCategoryDto)
        {
            var hasCategory = _categoryRepository.GetAll(x => x.Name.ToLower() == addCategoryDto.Name.ToLower()).ToList();

            if (hasCategory.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu isimde bir kategori zaten mevcut."
                };
            }

            var categoryEntity = new CategoryEntity()
            {
                Name = addCategoryDto.Name,
          
                Description = addCategoryDto.Description
            };

            _categoryRepository.Add(categoryEntity);

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Kategori başarıyla eklendi."
            };
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<ListCategoryDto> GetCategories()
        {
            var categoryEntities = _categoryRepository.GetAll().OrderBy(x => x.Name);

            var categoryDtoList = categoryEntities.Select(x => new ListCategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return categoryDtoList;
        }

        public EditCategoryDto GetCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetById(id);

            var editCategoryDto = new EditCategoryDto()
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description
            };

            return editCategoryDto;
        }

        public string GetCategoryName(int id)
        {
            return _categoryRepository.GetById(id).Name;
        }

        public void UpdateCategory(EditCategoryDto editCategoryDto)
        {
            var categoryEntity = _categoryRepository.GetById(editCategoryDto.Id);

            categoryEntity.Name = editCategoryDto.Name;
            categoryEntity.Description = editCategoryDto.Description;

            _categoryRepository.Update(categoryEntity);
        }
    }
}
