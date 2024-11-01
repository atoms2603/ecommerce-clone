using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class FilterTag : BaseEntity
    {
        public required string Name { get; set; }
        public FilterType Type { get; set; }

        public ICollection<ProductFilterTag> ProductFilterTags { get; set; } = new List<ProductFilterTag>();
        public ICollection<SellerFilterTag> SellerFilterTags { get; set; } = new List<SellerFilterTag>();
    }

    public enum FilterType
    {
        Delivery = 1,
        ProductCategory = 2,
        SellerCategory = 3,
        Promotion = 4
    }

    public class FilterTagConfig : BaseConfig<FilterTag>
    {
        public override void Configure(EntityTypeBuilder<FilterTag> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            base.Configure(builder);
        }
    }
}
