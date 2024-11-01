using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class RatingImage : BaseEntity
    {
        public Guid MediaFileId { get; set; }
        public Guid RatingId { get; set; }

        [ForeignKey("MediaFileId")] public virtual MediaFile MediaFile { get; set; } = null!;
        [ForeignKey("RatingId")] public virtual Rating Rating { get; set; } = null!;
    }

    public class RatingImageConfig : BaseConfig<RatingImage>
    {
        public override void Configure(EntityTypeBuilder<RatingImage> builder)
        {
            builder.HasOne(x => x.MediaFile).WithMany().HasForeignKey(x => x.MediaFileId);
            builder.HasOne(x => x.Rating).WithMany(x => x.RatingImages).HasForeignKey(x => x.RatingId);

            base.Configure(builder);
        }
    }
}
