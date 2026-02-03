using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.CustomerService.Entities;

namespace StoreFrontUK.Services.CustomerService.Data;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
                    .Property<DateTime>("CreatedDate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Customer>()
                    .Property<DateTime>("ModifiedDate");

        modelBuilder.Entity<Customer>()
                    .Property<byte[]>("RowVersion")
                    .IsRowVersion();

        modelBuilder.Entity<Customer>(builder =>
        {
            builder.OwnsOne(c => c.CustomerName, nb =>
            {
                nb.Property(n => n.Title).HasColumnName("CustomerTitle");
                nb.Property(n => n.FirstName).HasColumnName("CustomerFirstName");
                nb.Property(n => n.Surname).HasColumnName("CustomerSurname");
            });
        });



    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public DbSet<CustomerContact> CustomerContacts { get; set; }

    public DbSet<CustomerNote> CustomerNotes { get; set; }
}