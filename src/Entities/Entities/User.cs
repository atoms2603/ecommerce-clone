using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public RoleType Role { get; set; }
        public UserStatus UserStatus { get; set; }

        public required string Password { get; set; }
        public required string Salt { get; set; }
        public DateTime? FirstLoginAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public UserActivityStatus ActivityStatus { get; set; }
        public bool IsDefaultOTP { get; set; }
        public uint FailedLogged { get; set; }
        public uint FailedOtpLogged { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }

    public enum RoleType
    {

    }

    public enum UserStatus
    {
        [Display(Name = "Đang hoạt động")]
        Active = 1,

        [Display(Name = "Chưa hoạt động")]
        InActive = 2,

        [Display(Name = "Đã bị khóa")]
        Locked = 3
    }

    public enum UserActivityStatus
    {
        [Display(Name = "Chưa đăng nhập")]
        NonLogged = 1,

        [Display(Name = "Đang đăng nhập")]
        CurrentlyLogged = 2,

        [Display(Name = "Đã đăng xuất")]
        CurrentLoggedOut = 3
    }

    public class UserConfig : BaseConfig<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(a => a.Username).IsRequired();
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Phone).IsRequired();
            builder.Property(a => a.Avatar).IsRequired(false);
            builder.Property(a => a.Address).IsRequired(false);
            builder.Property(a => a.Role).IsRequired();
            builder.Property(a => a.UserStatus).IsRequired();
            builder.Property(a => a.Password).IsRequired();
            builder.Property(a => a.Salt).IsRequired();
            builder.Property(a => a.ActivityStatus).IsRequired();
            builder.Property(a => a.FirstLoginAt).IsRequired(false);
            builder.Property(a => a.LastLoginAt).IsRequired(false);
            builder.Property(a => a.IsDefaultOTP).IsRequired();
            builder.Property(a => a.FailedLogged).IsRequired();
            builder.Property(a => a.FailedOtpLogged).IsRequired();

            base.Configure(builder);
        }
    }
}
