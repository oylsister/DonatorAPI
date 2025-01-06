using DonatorAPI.Data.Dtos;
using DonatorAPI.Data.Entities;

namespace DonatorAPI.Data.Repositories.IRepository;

public interface IUserInfoRepository
{
    Task<ICollection<UserInfo>?> GetUserInfos(CancellationToken cancellationToken = default);
    Task<UserInfo?> GetUserInfoByAuth(string auth, CancellationToken cancellationToken = default);
    Task<bool> IsUserInfoExist(string auth, CancellationToken cancellationToken = default);
    Task<bool> CreateUserInfo(UserInfo userInfo, CancellationToken cancellationToken = default);
    Task<bool> UpdateUserInfo(UserInfoDto userInfo, CancellationToken cancellationToken = default);
    Task<bool> DeleteUserInfo(UserInfo auth, CancellationToken cancellationToken = default);
}
