using System.ComponentModel.DataAnnotations;

namespace StoreFrontUK.GlobalObjects.Inventory;

public record InventoryItemDTO
{
    [Required]
    public string ProductSku { get; set; } = string.Empty;

    [Required]
    [Range(0, 10000)]
    public int StockLevel { get; set; }

    [Required]
    public decimal Price { get; set; } = 0M;

}