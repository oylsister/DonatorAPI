namespace DonatorAPI.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    public string SteamdId64 { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public virtual IList<Purchase> Purchases { get; set; } = [];
}
