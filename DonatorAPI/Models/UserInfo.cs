namespace DonatorAPI.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public ulong Auth { get; set; }
        public string DonateTier { get; set; } = string.Empty;
        public DateTime ExpireTime { get; set; }
        public ICollection<PurchaseHistory> PurchaseHistories { get; set; }
    }
}
