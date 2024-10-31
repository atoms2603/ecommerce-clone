using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Product : BaseEntity
    {
        public Guid SellerId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string DefaultImageUri { get; set; }
        public ProductStatus Status { get; set; }
        public int TotalSold { get; set; }
        public double Rating { get; set; }

        [ForeignKey("SellerId")] public virtual Seller Seller { get; set; } = null!;

        public virtual ICollection<ProductProperty> ProductProperties { get; set; } = new List<ProductProperty>();
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }


    public enum ProductStatus
    {

    }

    public class ProductConfig : BaseConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne<Seller>().WithMany(x => x.Products).HasForeignKey(x => x.SellerId);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.DefaultImageUri).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.TotalSold).IsRequired();
            builder.Property(x => x.Rating).IsRequired();

            base.Configure(builder);
        }
    }
}
