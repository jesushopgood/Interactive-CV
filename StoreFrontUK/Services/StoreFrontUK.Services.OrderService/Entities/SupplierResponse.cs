using StoreFrontUK.Services.PickService.Models;

public class SupplierResponse
{
    public string SupplierName { get; set; } = string.Empty; 
    public decimal TotalPrice { get; set; }
    public List<PickOrderItem> Items { get; set; } = [];
}