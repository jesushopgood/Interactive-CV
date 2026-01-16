using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.OrderService.Entities;

namespace StoreFrontUK.Services.OrderService.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(op => op.OrderProductId);

            entity.Property(op => op.Sku)
                .IsRequired();

            entity.HasOne(op => op.Order)
                    .WithMany()
                    .HasForeignKey(op => op.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
        });
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; } 
}