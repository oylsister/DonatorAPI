namespace DonatorAPI.Data.Entities;

public class Purchase
{
    public int Id { get; set; }

    public string Auth { get; set; } = string.Empty;

    public float Price { get; set; }

    public DateTime PurchaseDate { get; set; }

    public UserInfo? UserInfo { get; set; }
}
