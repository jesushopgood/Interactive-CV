using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.ThirdParty.JunkFactory.Entities;

namespace StoreFrontUK.Services.ThirdParty.JunkFactory;

public class JunkFactoryDbContext : DbContext
{
    public JunkFactoryDbContext(DbContextOptions<JunkFactoryDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set;}

}