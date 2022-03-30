using Microsoft.AspNetCore.Mvc;
using SunriseClothingStore.Models;
using SunriseClothingStore.Models.Pages;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Controllers;

[Route("Category")]
public class CategoriesController : Controller
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository repository)
    {
        _categoryRepository = repository;
    }

    [HttpGet]
    public ViewResult CategoryPage(QueryOptions options) => View(_categoryRepository.GetCategories(options));

    [ApiExplorerSettings(IgnoreApi=true)]
    public IActionResult EditCategory(Guid id)
    {
        ViewBag.EditId = id;
        return View("CategoryPage", _categoryRepository.Categories);
    }
    
    #region Add

    [HttpPost("Add")]
    public IActionResult AddCategory(Category category)
    {
        _categoryRepository.AddCategory(category);
        return RedirectToAction(nameof(CategoryPage));
    }

    #endregion
    
    #region Update

    [HttpPost("Update")]
    public IActionResult UpdateCategory(Category category)
    {
        _categoryRepository.UpdateCategory(category);
        return RedirectToAction(nameof(CategoryPage));
    }
    
    #endregion

    #region Remove

    [HttpGet("Remove")]
    public IActionResult RemoveCategory(Guid key)
    {
        _categoryRepository.RemoveCategory(key);
        return RedirectToAction(nameof(CategoryPage));
    }

    #endregion
}
