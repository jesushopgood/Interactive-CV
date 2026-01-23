using System.ComponentModel.DataAnnotations;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.InventoryService.Entities;

public record Product : IEntityWithKey<string>
{
    [Key]
    public string Sku { get; set; } = string.Empty;

    [MinLength(10)]
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;

    public bool CanReorder { get; set; } = true;

    public string GetKey() => Sku;
}
