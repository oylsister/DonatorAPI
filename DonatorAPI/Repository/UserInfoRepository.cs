using DonatorAPI.Data;
using DonatorAPI.Interfaces;
using DonatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DonatorAPI.Repository
{
    public class UserInfoRepository : IUserInfo
    {
        private readonly DataContext _context;
        public UserInfoRepository(DataContext context)
        {
            _context = context;
        }

        public UserInfo? GetUserInfoByAuth(string auth)
        {
            //return _context.Users.Where(p => p.Auth == auth).FirstOrDefault();
            return _context.Users.Include(auth => auth.PurchaseHistories).Where(p => p.Auth == auth).FirstOrDefault();
        }

        public ICollection<UserInfo> GetUserInfos()
        {
            return _context.Users.Include(auth => auth.PurchaseHistories).OrderBy(p => p.Id).ToList();
        }

        public bool IsUserInfoExist(string auth)
        {
            return _context.Users.Any(p => p.Auth == auth);
        }
    }
}
