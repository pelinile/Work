using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Entities.Abstract
{
    public abstract class BaseEntity
    {
 
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }

    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.Property(x => x.CreatedAt).IsRequired(false);
            
            builder.Property(x => x.CreatedBy).IsRequired(false);

        }
    }
}
