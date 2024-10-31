using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class MediaFile : BaseEntity
    {
        public required string FileName { get; set; }
        public required string Key { get; set; }
        public string? RawUri { get; set; }
        public required string Uri { get; set; }
        public required string Extensions { get; set; }
        public FileType FileType { get; set; }
        public string? Content { get; set; }
    }

    public enum FileType
    {
        [Display(Name = "system_enum_file_type_image")]
        Image = 1,

        [Display(Name = "system_enum_file_type_video")]
        Video = 2,

        [Display(Name = "system_enum_file_type_file")]
        File = 3
    }

    public class MediaFileConfig : BaseConfig<MediaFile>
    {
        public override void Configure(EntityTypeBuilder<MediaFile> builder)
        {
            builder.Property(a => a.FileName).IsRequired();
            builder.Property(a => a.Key).IsRequired();
            builder.Property(a => a.RawUri).IsRequired(false);
            builder.Property(a => a.Uri).IsRequired();
            builder.Property(a => a.Extensions).IsRequired();
            builder.Property(a => a.FileType).IsRequired();
            builder.Property(a => a.Content).IsRequired(false);

            base.Configure(builder);
        }
    }
}
