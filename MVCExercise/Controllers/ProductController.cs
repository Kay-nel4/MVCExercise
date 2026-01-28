using Microsoft.AspNetCore.Mvc;
using MVCExercise.Data;
using MVCExercise.Models;

namespace MVCExercise.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }
    // GET
    public IActionResult Index()
    {
        var products = _repository.GetAllProducts();
        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {
        var product = _repository.GetProduct(id);
        return View(product);
    }

    public IActionResult UpdateProduct(Product product)
    {
        var prod =  _repository.GetProduct(product.ProductId);
        if (prod == null)
        {
           return View("ProductNotFound"); 
        }
        return View(product);
    }
}