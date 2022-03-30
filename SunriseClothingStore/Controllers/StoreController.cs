using Microsoft.AspNetCore.Mvc;
using SunriseClothingStore.Models.Pages;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Controllers;

[Route("Store")]
public class StoreController : Controller
{
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;

    public StoreController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public IActionResult Index(
        [FromQuery(Name = "options")] QueryOptions productOptions,
        QueryOptions categoryOptions,
        string categoryName)
    {
        ViewBag.Categories = _categoryRepository.GetCategories(categoryOptions);
        ViewBag.SelectedCategory = categoryName;
        return View(_productRepository.GetProducts(productOptions, categoryName));
    }
}