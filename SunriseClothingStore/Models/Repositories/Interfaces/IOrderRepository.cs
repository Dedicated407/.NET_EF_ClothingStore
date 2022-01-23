namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface IOrderRepository
{ 
    IQueryable<Order> Orders { get; }
    Order FindOrder(Guid id);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void RemoveOrder(Order order);
}