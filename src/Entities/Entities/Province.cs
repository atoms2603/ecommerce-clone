using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Province : BaseEntity
    {
        public required string OfficialProvinceId { get; set; }
        public string? Name { get; set; }
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }

        public ICollection<District> Districts { get; set; } = new List<District>();
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
    }

    public class ProvinceConfig : BaseConfig<Province>
    {
        public override void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(x => x.OfficialProvinceId).IsRequired();
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();

            base.Configure(builder);
        }
    }
}
