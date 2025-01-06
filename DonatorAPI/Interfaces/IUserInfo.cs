using DonatorAPI.Dto;
using DonatorAPI.Models;

namespace DonatorAPI.Interfaces
{
    public interface IUserInfo
    {
        Task<ICollection<UserInfo>?> GetUserInfos(CancellationToken cancellationToken = default);
        Task<UserInfo?> GetUserInfoByAuth(string auth, CancellationToken cancellationToken = default);
        Task<bool> IsUserInfoExist(string auth, CancellationToken cancellationToken = default);
        Task<bool> CreateUserInfo(UserInfo userInfo, CancellationToken cancellationToken = default);
        Task<bool> UpdateUserInfo(UserInfoDto userInfo, CancellationToken cancellationToken = default);
        Task<bool> DeleteUserInfo(UserInfo auth, CancellationToken cancellationToken= default);
        Task<bool> Save(CancellationToken cancellationToken = default);
    }
}
