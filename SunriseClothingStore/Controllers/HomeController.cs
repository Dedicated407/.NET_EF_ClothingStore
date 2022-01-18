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
}