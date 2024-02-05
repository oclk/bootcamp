using BootcampAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BootcampAPI;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
    public DbSet<ProductDefinition> ProductDefinitions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        SQLitePCL.Batteries.Init();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Products)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductFeature)
            .WithOne(pf => pf.Product)
            .HasForeignKey<ProductFeature>(pf => pf.ProductId);
    }
}
