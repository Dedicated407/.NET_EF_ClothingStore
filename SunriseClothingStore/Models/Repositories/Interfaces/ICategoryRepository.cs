namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> Categories { get; }
    Category FindCategory(Guid key);
    void AddCategory(Category product);
    void UpdateCategory(Category product);
    void RemoveCategory(Guid key);
}