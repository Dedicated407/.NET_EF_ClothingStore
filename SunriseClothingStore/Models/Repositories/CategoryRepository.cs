using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Models.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly StoreContext _context;
    public IQueryable<Category> Categories => _context.Categories;
    
    public CategoryRepository(StoreContext context) => _context = context;

    public Category FindCategory(Guid key)
    {
        return _context.Categories.Find(key);
    }

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    public void RemoveCategory(Guid key)
    {
        _context.Categories.Remove(FindCategory(key));
        _context.SaveChanges();
    }
}