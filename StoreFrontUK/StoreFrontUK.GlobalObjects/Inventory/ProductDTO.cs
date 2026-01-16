using System.ComponentModel.DataAnnotations;

namespace StoreFrontUK.GlobalObjects.Inventory;

public record ProductDTO
{
    [Key]
    public string Sku { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public bool CanReorder { get; set; } = true;
}