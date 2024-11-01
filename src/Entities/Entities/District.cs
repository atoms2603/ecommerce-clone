using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class District : BaseEntity
    {
        public Guid ProvinceId { get; set; }
        public required string OfficialDistrictId { get; set; }
        public required string Name { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }

        [ForeignKey("ProvinceId")] public virtual Province Province { get; set; } = null!;
    }

    public class DistrictConfig : BaseConfig<District>
    {
        public override void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasOne(x => x.Province).WithMany(x => x.Districts).HasForeignKey(x => x.ProvinceId);
            builder.Property(x => x.OfficialDistrictId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();

            base.Configure(builder);
        }
    }
}
