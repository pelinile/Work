﻿using Business.Dtos;
using Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICategoryService
    {
        ServiceMessage AddCategory(AddCategoryDto addCategoryDto);

        List<ListCategoryDto> GetCategories();

        EditCategoryDto GetCategory(int id);

        void UpdateCategory(EditCategoryDto editCategoryDto);

        void DeleteCategory(int id);

        string GetCategoryName(int id);
    }
}
