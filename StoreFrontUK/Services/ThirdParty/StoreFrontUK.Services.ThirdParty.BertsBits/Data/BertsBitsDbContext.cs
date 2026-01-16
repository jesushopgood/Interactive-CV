using System.Data;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.ThirdParty.Entities;

namespace StoreFrontUK.Services.ThirdParty.BertsBits.Data;

public class BertsBitsDbContext : DbContext
{
    public BertsBitsDbContext(DbContextOptions<BertsBitsDbContext> options) : base(options) { }
    
    public DbSet<StockItem> StockItems { get; set; }
}