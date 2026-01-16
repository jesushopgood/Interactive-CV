using System.ComponentModel.DataAnnotations;

namespace StoreFrontUK.Services.ThirdParty.JunkFactory.Entities;

public record Product
{
    [Key]
    public long Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public decimal PricePerUnit { get; set; }
    public int QuantityInStock { get; set; }
}