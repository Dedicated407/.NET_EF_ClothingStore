using Microsoft.EntityFrameworkCore;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Models.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly StoreContext _context;
    public IQueryable<Order> Orders => _context.Orders
        .Include(order => order.Lines)
        .ThenInclude(line => line.Product);

    public OrderRepository(StoreContext context) => _context = context;

    public Order FindOrder(Guid id)
    {
        return _context.Orders.Find(id);
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
    }

    public void RemoveOrder(Order order)
    {
        _context.Orders.Remove(order);
        _context.SaveChanges();
    }
}