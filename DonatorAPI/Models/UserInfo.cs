namespace DonatorAPI.Models
{
    public class UserInfo
    {
        public string Name { get; set; } = string.Empty;
        public ulong Auth { get; set; }
        public string DonateTier { get; set; } = string.Empty;
        public DateTime ExpireTime { get; set; }
    }
}
