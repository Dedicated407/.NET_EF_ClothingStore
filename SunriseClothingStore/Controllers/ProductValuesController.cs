using Microsoft.AspNetCore.Mvc;
using SunriseClothingStore.Models;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Controllers;

[ApiController]
[Route("api/products")]
public class ProductValuesController : Controller
{
    private readonly IWebServiceRepository _serviceRepository;

    public ProductValuesController(IWebServiceRepository repository) => _serviceRepository = repository;

    [HttpGet("id")]
    public object GetProduct([FromQuery] Guid id)
    {
        return _serviceRepository.GetProduct(id) ?? NotFound();
    }

    [HttpGet("withcategory/id")]
    public object GetProductWithCategory([FromQuery] Guid id)
    {
        return _serviceRepository.GetProductWithCategory(id) ?? NotFound();
    }

    [HttpGet("all")]
    public object GetProducts(int skip, int take)
    {
        return _serviceRepository.GetProducts(skip, take);
    }

    [HttpPost("add")]
    public Guid StoreProduct([FromBody] Product product)
    {
        return _serviceRepository.StoreProduct(product);
    }

    [HttpPut("update")]
    public void UpdateProduct([FromBody] Product product)
    {
        _serviceRepository.UpdateProduct(product);
    }

    [HttpDelete("remove")]
    public void RemoveProduct([FromQuery] Guid id)
    {
        _serviceRepository.RemoveProduct(id);
    }

}