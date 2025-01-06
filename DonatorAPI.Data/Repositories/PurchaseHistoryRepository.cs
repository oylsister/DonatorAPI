using DonatorAPI.Data.Entities;
using DonatorAPI.Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DonatorAPI.Data.Repositories;

public class PurchaseHistoryRepository(
    DonatorDataContext donatorDataContext
    ) : IPurchaseHistoryRepository
{
    private readonly DonatorDataContext _donatorDataContext = donatorDataContext;

    public async Task<bool> CreatePurchaseHistory(Purchase purchaseHistory, CancellationToken cancellationToken = default)
    {
        await _donatorDataContext.PurchaseHistories.AddAsync(purchaseHistory, cancellationToken);
        var saveResult = await _donatorDataContext.SaveChangesAsync(cancellationToken);

        return saveResult > 0;
    }

    public async Task<ICollection<Purchase>> GetPurchaseHistories(CancellationToken cancellationToken = default)
    {
        return await _donatorDataContext.PurchaseHistories
            .AsNoTracking()
            .OrderBy(ph => ph.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<Purchase>> GetUserPurchaseHistory(string auth, CancellationToken cancellationToken = default)
    {
        return await _donatorDataContext.PurchaseHistories
            .AsNoTracking()
            .Where(ph => ph.Auth == auth)
            .OrderBy(ph => ph.Id)
            .ToListAsync(cancellationToken);
    }
}
