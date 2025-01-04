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

        public ICollection<PurchaseHistory> GetPurchaseHistories(string auth)
        {
            return _context.PurchaseHistories.Where(p => p.Auth == auth).ToList();
        }

        public UserInfo? GetUserInfoByAuth(string auth)
        {
            return _context.Users.Where(p => p.Auth == auth).FirstOrDefault();
        }

        public UserInfo? GetUserInfoById(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<UserInfo> GetUserInfos()
        {
            return _context.Users.OrderBy(p => p.Id).ToList();
        }

        public bool IsUserInfoExist(string auth)
        {
            return _context.Users.Any(p => p.Auth == auth);
        }
    }
}
