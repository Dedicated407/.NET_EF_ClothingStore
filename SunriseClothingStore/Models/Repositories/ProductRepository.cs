using Microsoft.EntityFrameworkCore;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Models.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;
    public IQueryable<Product> Products => _context.Products.Include(product => product.Category);

    public ProductRepository(StoreContext context) => _context = context;

    #region Find

    public Product FindProduct(Guid key)
    {
        return _context.Products.Include(product => product.Category)
            .First(product => product.Id == key);
        // return _context.Products.Find(key);
    }

    #endregion

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

    #region Remove

    public void RemoveProduct(Guid key)
    {
        _context.Products.Remove(FindProduct(key));
        _context.SaveChanges();
    }

    #endregion
}