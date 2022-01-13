namespace SunriseClothingStore.Models;

public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public uint Quantity { get; set; }
}