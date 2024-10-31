using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid MediaFileId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? ProductPropertyId { get; set; }
        public int Position { get; set; }

        public virtual MediaFile MediaFile { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ProductProperty? ProductProperty { get; set; } 
    }

    public class ProductImageConfig : BaseConfig<ProductImage>
    {
        public override void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasOne<MediaFile>().WithMany().HasForeignKey(x => x.MediaFileId);
            builder.HasOne<Product>().WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId);
            builder.HasOne<ProductProperty>().WithOne(x => x.ProductImage).HasForeignKey<ProductImage>(x => x.ProductPropertyId);

            builder.Property(x => x.Position).IsRequired(); 

            base.Configure(builder);
        }
    }
}
