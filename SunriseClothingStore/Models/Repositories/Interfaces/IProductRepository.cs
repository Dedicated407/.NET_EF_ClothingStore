namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> Products { get; }
    Product GetProduct(Guid key);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
}