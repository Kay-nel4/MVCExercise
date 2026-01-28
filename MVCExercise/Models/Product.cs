namespace MVCExercise.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public bool OnSale { get; set; }
    public int StockLevel { get; set; }
}