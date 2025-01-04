using DonatorAPI.Models;

namespace DonatorAPI.Interfaces
{
    public interface IUserInfo
    {
        ICollection<UserInfo> GetUserInfos();
        UserInfo? GetUserInfo(ulong auth);
        UserInfo? GetUserInfo(int id);
        ICollection<PurchaseHistory> GetPurchaseHistories(ulong auth);
    }
}
