using DonatorAPI.Data.Dtos;
using DonatorAPI.Data.Entities;
using DonatorAPI.Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DonatorAPI.Data.Repositories;

public class UserInfoRepository(
    DonatorDataContext donatroDataContext
    ) : IUserInfoRepository
{
    private readonly DonatorDataContext _donatorDataContext = donatroDataContext;

    public async Task<bool> CreateUserInfo(UserInfo userInfo, CancellationToken cancellationToken = default)
    {
        await _donatorDataContext.AddAsync(userInfo, cancellationToken);
        return await Save(cancellationToken);
    }

    public async Task<bool> UpdateUserInfo(UserInfoDto userInfo, CancellationToken cancellationToken = default)
    {
        var user = await _donatorDataContext.Users.FirstOrDefaultAsync(user => user.Auth == userInfo.Auth, cancellationToken);
        if (user is null)
        {
            return false;
        }

        user.ExpireTime = userInfo.ExpireTime;
        user.DonateTier = userInfo.DonateTier;

        _donatorDataContext.Users.Update(user);

        return await Save(cancellationToken);
    }

    public async Task<bool> DeleteUserInfo(UserInfo info, CancellationToken cancellationToken = default)
    {
        var user = await _donatorDataContext.Users.FirstOrDefaultAsync(user => user.Auth == info.Auth, cancellationToken);
        if (user is null)
        {
            return false;
        }

        _donatorDataContext.Users.Remove(user);
        return await Save(cancellationToken);
    }

    public async Task<UserInfo?> GetUserInfoByAuth(string auth, CancellationToken cancellationToken = default)
    {
        return await _donatorDataContext.Users
            .AsNoTracking()
            .Include(auth => auth.PurchaseHistories)
            .Where(p => p.Auth == auth)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ICollection<UserInfo>?> GetUserInfos(CancellationToken cancellationToken = default)
    {
        return await _donatorDataContext.Users
            .AsNoTracking()
            .Include(auth => auth.PurchaseHistories)
            .OrderBy(p => p.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsUserInfoExist(string auth, CancellationToken cancellationToken = default)
    {
        return await _donatorDataContext.Users.AnyAsync(p => p.Auth == auth, cancellationToken);
    }

    private async Task<bool> Save(CancellationToken cancellationToken = default)
    {
        var saveResult = await _donatorDataContext.SaveChangesAsync(cancellationToken);
        return saveResult > 0;
    }
}
