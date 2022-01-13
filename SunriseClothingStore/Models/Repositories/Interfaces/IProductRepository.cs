namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> Products { get; }
    void AddProduct(Product product);
}