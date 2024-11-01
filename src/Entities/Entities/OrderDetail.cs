using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductPropertyId { get; set; }
        public required string ProductName { get; set; }
        public double Price { get; set; }
        public required string DefaultImageUri { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public string? Note { get; set; }

        [ForeignKey("OrderId")] public virtual Order Order { get; set; } = null!;
    }

    public class OrderDetailConfig : BaseConfig<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            builder.Property(e => e.ProductName).IsRequired();
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.DefaultImageUri).IsRequired();
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.TotalAmount).IsRequired();
            builder.Property(e => e.Note).IsRequired(false);

            base.Configure(builder);
        }
    }
}
