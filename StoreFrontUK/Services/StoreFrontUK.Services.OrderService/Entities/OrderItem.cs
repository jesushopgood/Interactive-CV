using System.ComponentModel.DataAnnotations;

public record OrderItem
{
    [Key]
    public long OrderItemId { get; set; }

    public long OrderId { get; set; }

    public string Sku { get; set; } = string.Empty;

    public int Quantity { get; set; }
}