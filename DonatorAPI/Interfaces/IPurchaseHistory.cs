using DonatorAPI.Models;

namespace DonatorAPI.Interfaces
{
    public interface IPurchaseHistory
    {
        Task<ICollection<PurchaseHistory>> GetPurchaseHistories(CancellationToken cancellationToken = default);
        Task<ICollection<PurchaseHistory>> GetUserPurchaseHistory(string auth, CancellationToken cancellationToken = default);
        Task<bool> AddPurchaseHistory(PurchaseHistory purchaseHistory, CancellationToken cancellationToken = default);
    }
}
