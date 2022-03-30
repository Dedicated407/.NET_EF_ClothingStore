using Microsoft.EntityFrameworkCore;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Models.Repositories;

public sealed class WebServiceRepository : IWebServiceRepository
{
    private readonly StoreContext _context;

    public WebServiceRepository(StoreContext context) => _context = context;

    public object? GetProduct(Guid id)
    {
        return _context.Products.Select(p => new
        {
            p.Id,
            p.Name,
            p.PurchasePrice,
            p.SalePrice,
            p.Quantity,
            p.Description
        }).FirstOrDefault(p => p.Id == id);
    }

    public object? GetProductWithCategory(Guid id)
    {
        return _context.Products
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.PurchasePrice,
                p.SalePrice,
                p.Quantity,
                p.Description,
                p.CategoryId,
                Category = new { p.Category.Id, p.Category.Name, p.Category.Description }
            })
            .FirstOrDefault(p => p.Id == id);
    }

    public object GetProducts(int skip, int take)
    {
        return _context.Products.Include(p => p.Category)
            .OrderBy(р => р.Id)
            .Skip(skip)
            .Take(take)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.PurchasePrice,
                p.SalePrice,
                p.Quantity,
                p.Description,
                p.CategoryId,
                Category = new { p.Category.Id, p.Category.Name, p.Category.Description }
            });
    }

    public Guid StoreProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product.Id;
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void RemoveProduct(Guid id)
    {
        _context.Products.Remove(new Product { Id = id });
        _context.SaveChanges();
    }
}