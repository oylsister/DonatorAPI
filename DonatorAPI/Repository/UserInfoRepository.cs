﻿using DonatorAPI.Data;
using DonatorAPI.Dto;
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

        public async Task<bool> UpdateUserInfo(UserInfoDto userInfo, CancellationToken cancellationToken = default)
        {
            var user = await GetUserInfoByAuth(userInfo.Auth);

            // if not found then don't do it.
            if (user == null)
                return false;

            // null meaning no limit so we change userinfo to null just like that.  
            if (user.DonateTier == "permanent")
                userInfo.ExpireTime = null;

            user.ExpireTime = userInfo.ExpireTime;
            user.DonateTier = userInfo.DonateTier;

            _context.Update(user);
            return await Save(cancellationToken);
        }

        public async Task<bool> DeleteUserInfo(UserInfo info, CancellationToken cancellationToken = default)
        {
            _context.Remove(info);
            return await Save(cancellationToken);
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
            var user = await _context.Users.Where(p => p.Auth == auth).FirstOrDefaultAsync();
            return user != null;
        }

        public async Task<bool> Save(CancellationToken cancellationToken = default)
        {
            var saved = await _context.SaveChangesAsync(cancellationToken);
            return saved > 0 ? true : false;
        }
    }
}
