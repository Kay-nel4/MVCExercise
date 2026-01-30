using System.Data;
using MVCExercise.Models;
using Dapper;

namespace MVCExercise.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;
    private IProductRepository _productRepositoryImplementation;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products;");
    }

    public Product GetProduct(int id)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM Products WHERE ProductId = @id;", new {id});
   }

    public void UpdateProduct(Product product)
    {
        _connection.Execute("UPDATE Products SET Name = @name, Price = @price WHERE ProductId = @productId;", 
            new {name = product.Name, price = product.Price, productId = product.ProductId});
    }

    public void InsertProduct(Product productToInsert)
    {
        _connection.Execute("INSERT INTO products (NAME, PRICE, CategoryId) VALUES (@name, @price, @categoryId); ",
            new {name = productToInsert.Name, price = productToInsert.Price, categoryId = productToInsert.CategoryId });
    }

    public IEnumerable<Category> GetCategories()
    {
        return _connection.Query<Category>("SELECT * FROM categories;");
    }

    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    }

    public void DeleteProduct(Product product)
    {
        _connection.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new { id = product.ProductId });
        _connection.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductId });
        _connection.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductId });
    }


}