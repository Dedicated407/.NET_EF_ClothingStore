namespace SunriseClothingStore.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
}