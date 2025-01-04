using DonatorAPI.Data;
using DonatorAPI.Interfaces;
using DonatorAPI.Models;

namespace DonatorAPI.Repository
{
    public class UserInfoRepository : IUserInfo
    {
        private readonly DataContext _context;
        public UserInfoRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<PurchaseHistory> GetPurchaseHistories(ulong auth)
        {
            return [.. _context.PurchaseHistories.Where(p => p.Auth == auth)];
        }

        public UserInfo? GetUserInfo(ulong auth)
        {
            return _context.Users.Where(p => p.Auth == auth).FirstOrDefault();
        }

        public UserInfo? GetUserInfo(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<UserInfo> GetUserInfos()
        {
            return [.. _context.Users.OrderBy(p => p.Id)];
        }
    }
}
