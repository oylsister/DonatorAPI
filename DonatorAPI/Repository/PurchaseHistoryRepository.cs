using DonatorAPI.Data;
using DonatorAPI.Interfaces;
using DonatorAPI.Models;

namespace DonatorAPI.Repository
{
    public class PurchaseHistoryRepository : IPurchaseHistory
    {
        private readonly DataContext _context;
        public PurchaseHistoryRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<PurchaseHistory> GetPurchaseHistories()
        {
            return _context.PurchaseHistories.OrderBy(p => p.Id).ToList();
        }

        public ICollection<PurchaseHistory> GetUserPurchaseHistory(string auth)
        {
            return _context.PurchaseHistories.Where(p => p.Auth == auth).ToList();
        }
    }
}
