using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Models.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;
    public ProductRepository(StoreContext context) => _context = context;

    #region Add

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    #endregion

    #region Update

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    #endregion

    #region Get

    public Product GetProduct(Guid key)
    {
        return _context.Products.Find(key)!;
    }

    public IEnumerable<Product> Products => _context.Products;

    #endregion

    #region Remove

    public void RemoveProduct(Guid key)
    {
        _context.Products.Remove(GetProduct(key));
        _context.SaveChanges();
    }

    #endregion
}