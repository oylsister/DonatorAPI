using DonatorAPI.Models;

namespace DonatorAPI.Interfaces
{
    public interface IUserInfo
    {
        ICollection<UserInfo> GetUserInfos();
        UserInfo? GetUserInfoByAuth(string auth);
        UserInfo? GetUserInfoById(int id);
        ICollection<PurchaseHistory> GetPurchaseHistories(string auth);
        bool IsUserInfoExist(string auth);
    }
}
