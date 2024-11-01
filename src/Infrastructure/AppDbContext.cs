using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MediaFileConfig());
        modelBuilder.ApplyConfiguration(new OrderConfig());
        modelBuilder.ApplyConfiguration(new OrderDetailConfig());
        modelBuilder.ApplyConfiguration(new PaymentConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new ProductImageConfig());
        modelBuilder.ApplyConfiguration(new ProductPropertyConfig());
        modelBuilder.ApplyConfiguration(new RatingConfig());
        modelBuilder.ApplyConfiguration(new RatingImageConfig());
        modelBuilder.ApplyConfiguration(new SellerConfig());
        modelBuilder.ApplyConfiguration(new TransactionConfig());
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new ProvinceConfig());
        modelBuilder.ApplyConfiguration(new DistrictConfig());
        modelBuilder.ApplyConfiguration(new FilterTagConfig());
        modelBuilder.ApplyConfiguration(new ProductFilterTagConfig());
        modelBuilder.ApplyConfiguration(new SellerFilterTagConfig());
    }

    public DbSet<MediaFile> MediaFiles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductProperty> ProductProperties { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<RatingImage> RatingImages { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<FilterTag> FilterTags { get; set; }
    public DbSet<ProductFilterTag> ProductFilterTags { get; set; }
    public DbSet<SellerFilterTag> SellerFilterTags { get; set; }
}
