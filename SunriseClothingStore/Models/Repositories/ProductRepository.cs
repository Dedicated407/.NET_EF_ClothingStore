using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Models.Repositories;

public class ProductRepository : IProductRepository
{
    private List<Product> _products = new();
    public IEnumerable<Product> Products => _products;
    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}