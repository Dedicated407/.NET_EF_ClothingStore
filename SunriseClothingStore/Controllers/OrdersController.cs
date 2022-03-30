using Microsoft.AspNetCore.Mvc;
using SunriseClothingStore.Models;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Controllers;

[Route("Order")]
public class OrdersController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public OrdersController(IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public IActionResult Index() => View(_orderRepository.Orders);

    [HttpGet("Edit")]
    public IActionResult EditOrder(Guid id)
    {
        var products = _productRepository.Products;
        Order order = id == Guid.Empty
            ? new Order()
            : _orderRepository.FindOrder(id);

        IDictionary<Guid, OrderLine> linesMap =
            order.Lines?.ToDictionary(line => line.ProductId) ?? new Dictionary<Guid, OrderLine>();

        ViewBag.Lines = products.Select(p => linesMap.ContainsKey(p.Id)
            ? linesMap[p.Id]
            : new OrderLine { Product = p, ProductId = p.Id, Quantity = 0 });

        return View(order);
    }

    #region Update

    [HttpPost("AddOrUpdate")]
    public IActionResult UpdateOrder(Order order)
    {
        order.Lines = order.Lines
            .Where(line => line.Id != Guid.Empty || (line.Id == Guid.Empty && line.Quantity > 0))
            .ToList();
        
        if (order.Id == Guid.Empty)
        {
            _orderRepository.AddOrder(order);
        }
        else
        {
            _orderRepository.UpdateOrder(order);
        }

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Remove

    [HttpPost("Remove")]
    public IActionResult RemoveOrder(Order order)
    {
        _orderRepository.RemoveOrder(order);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}