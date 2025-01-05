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

        public async Task<bool> CreateUserInfo(UserInfo userInfo, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(userInfo);
            return await Save();
        }

        public async Task<UserInfo?> GetUserInfoByAuth(string auth, CancellationToken cancellationToken = default)
        {
            //return _context.Users.Where(p => p.Auth == auth).FirstOrDefault();
            return await _context.Users.Include(auth => auth.PurchaseHistories).Where(p => p.Auth == auth).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ICollection<UserInfo>?> GetUserInfos(CancellationToken cancellationToken = default)
        {
            return await _context.Users.Include(auth => auth.PurchaseHistories).OrderBy(p => p.Id).ToListAsync(cancellationToken);
        }

        public async Task<bool> IsUserInfoExist(string auth, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AnyAsync(p => p.Auth == auth);
        }

        public async Task<bool> Save(CancellationToken cancellationToken = default)
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
