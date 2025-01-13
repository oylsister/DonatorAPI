namespace DonatorAPI.Data.Entities;

public class Purchase
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
