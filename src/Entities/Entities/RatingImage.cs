using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class RatingImage : BaseEntity
    {
        public Guid MediaFileId { get; set; }
        public Guid RatingId { get; set; }

        public virtual MediaFile MediaFile { get; set; } = null!;
        public virtual Rating Rating { get; set; } = null!;
    }

    public class RatingImageConfig : BaseConfig<RatingImage>
    {
        public override void Configure(EntityTypeBuilder<RatingImage> builder)
        {
            builder.HasOne<MediaFile>().WithMany().HasForeignKey(x => x.MediaFileId);
            builder.HasOne<Rating>().WithMany(x => x.RatingImages).HasForeignKey(x => x.RatingId);

            base.Configure(builder);
        }
    }
}
