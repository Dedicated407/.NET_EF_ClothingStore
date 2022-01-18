using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Models.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;
    public ProductRepository(StoreContext context) => _context = context;
    
    public IEnumerable<Product> Products => _context.Products;

    #region Add

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    #endregion
}