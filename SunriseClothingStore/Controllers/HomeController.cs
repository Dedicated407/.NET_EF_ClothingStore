using Microsoft.AspNetCore.Mvc;
using SunriseClothingStore.Models;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Controllers;

[Route("Home")]
public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;

    public HomeController(IProductRepository repository)
    {
        _productRepository = repository;
    }

    [HttpGet]
    public ViewResult HomePage() => View(_productRepository.Products as IQueryable<Product>);

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
        return RedirectToAction(nameof(HomePage));
    }

    [HttpGet("Update")]
    public IActionResult UpdateProduct(Guid key)
    {
        return View(_productRepository.GetProduct(key));
    }

    [HttpPost("Update")]
    public IActionResult UpdateProduct(Product product)
    {
        _productRepository.UpdateProduct(product);
        return RedirectToAction(nameof(HomePage));
    }
}