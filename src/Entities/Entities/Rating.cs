using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Rating : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string? Description { get; set; }
        public double RatePoint { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;

        public ICollection<RatingImage> RatingImages { get; set; } = new List<RatingImage>();
    }

    public class RatingConfig : BaseConfig<Rating>
    {
        public override void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Ratings).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Product).WithMany(x => x.Ratings).HasForeignKey(x => x.ProductId);

            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.RatePoint).IsRequired();

            base.Configure(builder);
        }
    }
}
