using DonatorAPI.Models;

namespace DonatorAPI.Interfaces
{
    public interface IUserInfo
    {
        ICollection<UserInfo> GetUserInfos();
        UserInfo? GetUserInfoByAuth(string auth);
        bool IsUserInfoExist(string auth);
        bool CreateUserInfo(UserInfo userInfo);
        bool Save();
    }
}
