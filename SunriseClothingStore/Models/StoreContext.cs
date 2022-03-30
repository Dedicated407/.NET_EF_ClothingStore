using Microsoft.EntityFrameworkCore;

namespace SunriseClothingStore.Models;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasIndex(product => product.Name);
        modelBuilder.Entity<Product>().HasIndex(product => product.PurchasePrice);
        modelBuilder.Entity<Product>().HasIndex(product => product.SalePrice);
        modelBuilder.Entity<Category>().HasIndex(category => category.Name);
        modelBuilder.Entity<Category>().HasIndex(category => category.Description);
    }

}