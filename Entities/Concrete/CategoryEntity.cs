using Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<ProductEntity> Products { get; set; }

    }

    public class CategoryEntityConfiguration : BaseConfiguration<CategoryEntity>
    {

        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }


    }

}
