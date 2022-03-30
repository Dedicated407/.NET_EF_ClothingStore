using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SunriseClothingStore.Infrastructure;
using SunriseClothingStore.Models;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Controllers;

[Route("Cart")]
public class CartController : Controller
{
    private IOrderRepository _orderRepository;

    public CartController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public IActionResult Index(string returnUri)
    {
        ViewBag.returnUri = returnUri;
        return View(GetCart());
    }

    [HttpPost("Add")]
    public IActionResult AddToCart(Product product, string returnUri)
    {
        SaveCart(GetCart().AddItem(product, 1));
        return RedirectToAction(nameof(Index), new { returnUri });
    }

    [HttpPost("Remove")]
    public IActionResult RemoveFromCart(Guid productId, string returnUri)
    {
        SaveCart(GetCart().RemoveItem(productId));
        return RedirectToAction(nameof(Index), new { returnUri });
    }

    public IActionResult CreateOrder() => View();

    [HttpPost("CreateOrder")]
    public IActionResult CreateOrder(Order order)
    {
        order.Lines = GetCart().Selections.Select(s => new OrderLine { ProductId = s.ProductId, Quantity = s.Quantity })
            .ToList();
        _orderRepository.AddOrder(order);
        SaveCart(new Cart());
        return RedirectToAction(nameof(Completed));
    }

    public IActionResult Completed() => View();
    
    private Cart GetCart() => HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();

    private void SaveCart(Cart cart) => HttpContext.Session.SetJson("Cart", cart);

    public IViewComponentResult Invoke(ISession session) =>
        new ViewViewComponentResult
        {
            ViewData = new ViewDataDictionary<Cart>(ViewData, session.GetJson<Cart>("Cart"))
        };
}