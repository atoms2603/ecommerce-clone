using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid UserId { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }

        [ForeignKey("UserId")] public virtual User User { get; set; } = null!;
    }

    public enum TransactionType
    {
        Payment = 1, 
        Topup = 2
    }

    public class TransactionConfig : BaseConfig<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne<User>().WithMany(x => x.Transactions).HasForeignKey(x => x.UserId);  
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            base.Configure(builder);
        }
    }
}
