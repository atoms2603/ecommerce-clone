using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class ProductProperty : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid ProductImageId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public int Remaining { get; set; }

        [ForeignKey("ProductId")] public Product Product { get; set; } = null!;
        [ForeignKey("ProductImageId")] public ProductImage ProductImage { get; set; } = null!;
    }

    public class ProductPropertyConfig : BaseConfig<ProductProperty>
    {
        public override void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Remaining).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.ProductProperties).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.ProductImage).WithOne(x => x.ProductProperty).HasForeignKey<ProductProperty>(x => x.ProductImageId);

            base.Configure(builder);
        }
    }
}
