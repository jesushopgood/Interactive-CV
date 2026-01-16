using System.ComponentModel.DataAnnotations;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.InventoryService.Entities;

public record InventoryItem : IHasKey<string>
{
    [Key]
    public string ProductSku { get; set; } = string.Empty;

    [Range(0, 10000)]
    public int StockLevel { get; set; }

    [Required]
    public decimal Price { get; set; } = 0M;

    public string GetKey() => ProductSku;
}