using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Seller : BaseEntity
    {
        public Guid UserId { get; set; }
        public required string ShopName { get; set; }
        public required string ShopDescription { get; set; }
        public double Rating { get; set; }
        public required string LinkShop { get; set; }

        [ForeignKey("UserId")] public virtual User User { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public class SellerConfig : BaseConfig<Seller>
    {
        public override void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);

            builder.Property(x => x.ShopName).IsRequired();
            builder.Property(x => x.ShopDescription).IsRequired(false);
            builder.Property(x => x.Rating).IsRequired();
            builder.Property(x => x.LinkShop).IsRequired();

            base.Configure(builder);
        }
    }
}
