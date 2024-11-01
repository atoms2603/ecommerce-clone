using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class SellerFilterTag : BaseEntity
    {
        public Guid SellerId { get; set; }
        [ForeignKey("SellerId")] public virtual Seller Seller { get; set; } = null!;

        public Guid FilterTagId { get; set; }
        [ForeignKey("FilterTagId")] public virtual FilterTag FilterTag { get; set; } = null!;
    }

    public class SellerFilterTagConfig : BaseConfig<SellerFilterTag>
    {
        public override void Configure(EntityTypeBuilder<SellerFilterTag> builder)
        {
            builder.HasOne(x => x.Seller).WithMany(x => x.SellerFilterTags).HasForeignKey(x => x.SellerId);
            builder.HasOne(x => x.FilterTag).WithMany(x => x.SellerFilterTags).HasForeignKey(x => x.FilterTagId);

            base.Configure(builder);
        }
    }
}