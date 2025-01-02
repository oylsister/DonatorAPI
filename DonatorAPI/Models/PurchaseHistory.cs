namespace DonatorAPI.Models
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public ulong Auth { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
