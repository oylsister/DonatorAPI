using System.Threading;
using DonatorAPI.Data;
using DonatorAPI.Interfaces;
using DonatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DonatorAPI.Repository
{
    public class PurchaseHistoryRepository : IPurchaseHistory
    {
        private readonly DataContext _context;
        public PurchaseHistoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PurchaseHistory>> GetPurchaseHistories(CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseHistories.OrderBy(p => p.Id).ToListAsync(cancellationToken);
        }

        public async Task<ICollection<PurchaseHistory>> GetUserPurchaseHistory(string auth, CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseHistories.Where(p => p.Auth == auth).ToListAsync(cancellationToken);
        }

        public async Task<bool> AddPurchaseHistory(PurchaseHistory purchaseHistory, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(purchaseHistory, cancellationToken);
            return await Save(cancellationToken);
        }

        public async Task<bool> Save(CancellationToken cancellationToken = default)
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
