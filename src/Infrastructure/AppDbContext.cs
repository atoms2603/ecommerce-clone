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
    }

    public DbSet<Product> Products { get; set; }
}
