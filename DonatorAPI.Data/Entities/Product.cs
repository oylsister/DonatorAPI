namespace DonatorAPI.Data.Entities;

public class Product
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public Guid CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public virtual IList<Purchase> Purchases { get; set; } = [];
}
