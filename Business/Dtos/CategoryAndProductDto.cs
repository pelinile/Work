using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class CategoryAndProductDto
    {
    }

    public class AddCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class EditCategoryDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class ListCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class AddProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryId { get; set; }
        

    }

    public class EditProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryId { get; set; }
        
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
