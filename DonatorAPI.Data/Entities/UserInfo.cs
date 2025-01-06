namespace DonatorAPI.Data.Entities;

public class UserInfo
{
    public int Id { get; set; }

    public string Auth { get; set; } = string.Empty;

    public string DonateTier { get; set; } = string.Empty;

    public DateTime? ExpireTime { get; set; }

    public ICollection<Purchase>? PurchaseHistories { get; set; } = [];
}
