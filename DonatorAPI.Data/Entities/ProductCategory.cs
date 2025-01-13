namespace DonatorAPI.Data.Entities;

public class ProductCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public virtual IList<Product> Products { get; set; } = [];
}
