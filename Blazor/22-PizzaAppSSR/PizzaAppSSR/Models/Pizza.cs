namespace PizzaAppSSR.Models;

public sealed class Pizza
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Ingredients { get; set; }
    public required string ImageUrl { get; set; }
    public required decimal Price { get; set; }
}
