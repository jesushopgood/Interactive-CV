using System.ComponentModel.DataAnnotations;

namespace StoreFrontUK.Services.ThirdParty.Entities;

public record StockItem
{
    [Key]
    public long Id { get; set; }

    public string Sku { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockLevel { get; set; }
}