using Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }

    public class ProductEntityConfiguration : BaseConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.UnitPrice)
                .IsRequired(false);
            //base.Configure(builder);
        }
    }
}
