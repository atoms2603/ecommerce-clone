using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid SellerId { get; set; }
        public required string OrderCode { get; set; }
        public required string CustomerName { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public OrderStatus Status { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public double TotalAmount { get; set; }
        public double ShippingFee { get; set; }
        public int ItemQuantity { get; set; }
        public string? Note { get; set; }

        [ForeignKey("UserId")] public virtual User User { get; set; } = null!;
        [ForeignKey("SellerId")] public virtual Seller Seller { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }

    public enum DeliveryType
    {

    }

    public enum OrderStatus
    {

    }

    public class OrderConfig : BaseConfig<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne<User>().WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
            builder.HasOne<Seller>().WithMany(x => x.Orders).HasForeignKey(x => x.SellerId);

            builder.Property(e => e.OrderCode).IsRequired();
            builder.Property(e => e.CustomerName).IsRequired();
            builder.Property(e => e.Address).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired();
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.DeliveryType).IsRequired();
            builder.Property(e => e.TotalAmount).IsRequired();
            builder.Property(e => e.ShippingFee).IsRequired();
            builder.Property(e => e.Note).IsRequired(false);

            base.Configure(builder);
        }
    }
}
