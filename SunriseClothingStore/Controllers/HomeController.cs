using Microsoft.AspNetCore.Mvc;
using SunriseClothingStore.Models;
using SunriseClothingStore.Models.Pages;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Controllers;

[ApiExplorerSettings(IgnoreApi=true)]
[Route("Product")]
public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    [HttpGet("/")]
    public ViewResult HomePage(QueryOptions options) => View(_productRepository.GetProducts(options));

    #region Update
    
    [HttpGet("Update")]
    public IActionResult UpdateProduct(Guid key)
    {
        ViewBag.Categories = _categoryRepository.Categories;
        return View(key == Guid.Empty ? new Product() : _productRepository.FindProduct(key));
    }

    [HttpPost("Update")]
    public IActionResult UpdateProduct(Product product)
    {
        if (product.Id == Guid.Empty)
        {
            _productRepository.AddProduct(product);
        }
        else
        {
            _productRepository.UpdateProduct(product);
        }
        return RedirectToAction(nameof(HomePage));
    }
    
    #endregion

    #region Remove

    [HttpGet("Remove")]
    public IActionResult RemoveProduct(Guid key)
    {
        _productRepository.RemoveProduct(key);
        return RedirectToAction(nameof(HomePage));
    }

    #endregion
}