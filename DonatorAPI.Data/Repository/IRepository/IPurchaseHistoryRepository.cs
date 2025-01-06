using DonatorAPI.Data.Entities;

namespace DonatorAPI.Data.Repository.IRepository;

public interface IPurchaseHistoryRepository
{
    Task<ICollection<Purchase>> GetPurchaseHistories(CancellationToken cancellationToken = default);
    Task<ICollection<Purchase>> GetUserPurchaseHistory(string auth, CancellationToken cancellationToken = default);
    Task<bool> CreatePurchaseHistory(Purchase purchaseHistory, CancellationToken cancellationToken = default);
}
