using System.ComponentModel.DataAnnotations;

namespace StoreFrontUK.Services.ThirdParty.UncleNobbies.Entities;

public record StockUnit
{
    [Key]
    public long Sid { get; set; }

    public string Sku { get; set; } = string.Empty;

    public decimal SalePrice { get; set; }

    public int StockCount { get; set; }
}