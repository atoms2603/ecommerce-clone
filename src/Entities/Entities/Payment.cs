using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }
        public double Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentType Type { get; set; }    

        [ForeignKey("OrderId")] public virtual Order Order { get; set; } = null!;
    }

    public enum PaymentStatus
    {

    }

    public enum PaymentType
    {

    }

    public class PaymentConfig : BaseConfig<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.HasOne(x => x.Order).WithMany(x => x.Payments).HasForeignKey(x => x.OrderId);

            base.Configure(builder);
        }
    }
}
