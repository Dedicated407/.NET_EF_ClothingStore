namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface IProductRepository
{
    IQueryable<Product> Products { get; }
    Product FindProduct(Guid key);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void RemoveProduct(Guid key);
}