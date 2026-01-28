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
        return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductId = @id", new {id});
   }

    public void UpdateProduct(Product product)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE @productId = @id;", 
            new {name = product.Name, price = product.Price, productId = product.ProductId});
    }
}