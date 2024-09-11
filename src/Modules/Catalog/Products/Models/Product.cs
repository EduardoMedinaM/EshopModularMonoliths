namespace Catalog.Products.Models;

public class Product : Entity<Guid>
{
    public string Name { get; private set; } = default!;
    public List<string> Category { get; private set; } = [];
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public decimal Price { get; private set; }

    /*
     * Recipe of the Rich model strategy
     * Add a create method for initializing the object
     * Make property setters private to enforce encapsulation
     * Add an Update method to allow changing the properties
     */
    public static Product Create(
        Guid id,
        string name,
        List<string> category,
        string description,
        string imageFile,
        decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        Product product = new()
        {
            Id = id,
            Name = name,
            Category = category,
            Description = description,
            ImageFile = imageFile,
            Price = price
        };

        return product;
    }

    public void Update(
        string name,
        List<string> category,
        string description,
        string imageFile,
        decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;

        /*If price has changed, raise ProductPriceChanged domain event*/
    }
}
