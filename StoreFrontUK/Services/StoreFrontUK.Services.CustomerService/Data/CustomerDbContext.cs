using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.CustomerService.Entities;

namespace StoreFrontUK.Services.CustomerService.Data;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public DbSet<CustomerContact> CustomerContacts { get; set; }
    
    public DbSet<CustomerNote> CustomerNotes { get; set; }
}