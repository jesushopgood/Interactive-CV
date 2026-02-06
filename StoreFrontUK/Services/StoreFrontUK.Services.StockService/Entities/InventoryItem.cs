using System.ComponentModel.DataAnnotations;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.StockService.Entities;

public record InventoryItem : IEntityWithKey<string>
{
    [Key]
    public string ProductSku { get; set; } = string.Empty;

    [Range(0, 10000)]
    public int StockLevel { get; set; }

    [Required]
    public decimal Price { get; set; } = 0M;

    public string GetKey() => ProductSku;
}