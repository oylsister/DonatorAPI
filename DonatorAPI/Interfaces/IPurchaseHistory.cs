using DonatorAPI.Models;

namespace DonatorAPI.Interfaces
{
    public interface IPurchaseHistory
    {
        ICollection<PurchaseHistory> GetPurchaseHistories();
        ICollection<PurchaseHistory> GetUserPurchaseHistory(string auth);
    }
}
