using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.ThirdParty.UncleNobbies.Entities;

namespace StoreFrontUK.Services.ThirdParty.UncleNobbies.Data;

public class UncleNobbiesDbContext : DbContext
{
    public UncleNobbiesDbContext(DbContextOptions<UncleNobbiesDbContext> options) : base(options)
    {
    }

    public DbSet<StockUnit> StockUnits { get; set; }
}