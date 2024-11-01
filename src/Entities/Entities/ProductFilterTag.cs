using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ProductFilterTag : BaseEntity
    {
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")] public virtual Product Product { get; set; } = null!;

        public Guid FilterTagId { get; set; }
        [ForeignKey("FilterTagId")] public virtual FilterTag FilterTag { get; set; } = null!;
    }

    public class ProductFilterTagConfig : BaseConfig<ProductFilterTag>
    {
        public override void Configure(EntityTypeBuilder<ProductFilterTag> builder)
        {
            builder.HasOne(x => x.Product).WithMany(x => x.ProductFilterTags).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.FilterTag).WithMany(x => x.ProductFilterTags).HasForeignKey(x => x.FilterTagId);

            base.Configure(builder);
        }
    }
}
