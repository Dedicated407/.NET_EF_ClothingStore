namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface IWebServiceRepository
{
    public object? GetProduct(Guid id);
    public object? GetProductWithCategory(Guid id);
    public object GetProducts(int skip, int take);
    public Guid StoreProduct(Product product);
    public void UpdateProduct(Product product);
    public void RemoveProduct(Guid id);
}