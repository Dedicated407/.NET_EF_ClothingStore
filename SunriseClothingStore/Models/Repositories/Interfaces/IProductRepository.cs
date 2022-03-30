using SunriseClothingStore.Models.Pages;

namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface IProductRepository
{
    IQueryable<Product> Products { get; }
    PagedList<Product> GetProducts(QueryOptions options, string? categoryName = null);
    public IQueryable<Product> GetAllProducts();
    Product FindProduct(Guid key);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void RemoveProduct(Guid key);
}