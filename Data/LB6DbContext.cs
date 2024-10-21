using ASPNET6.Models;

namespace ASPNET6.Data;
using Microsoft.EntityFrameworkCore;

public class Lb6DbContext(DbContextOptions<Lb6DbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Order)
            .WithMany(o => o.Products)
            .HasForeignKey(p => p.OrderId);
    }
}