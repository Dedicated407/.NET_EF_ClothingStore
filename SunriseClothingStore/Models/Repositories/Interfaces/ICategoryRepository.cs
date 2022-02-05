using SunriseClothingStore.Models.Pages;

namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> Categories { get; }
    PagedList<Category> GetCategories(QueryOptions options);
    Category FindCategory(Guid key);
    void AddCategory(Category product);
    void UpdateCategory(Category product);
    void RemoveCategory(Guid key);
}