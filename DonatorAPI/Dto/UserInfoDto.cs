using System.ComponentModel.DataAnnotations.Schema;

namespace DonatorAPI.Dto
{
    public class UserInfoDto
    {
        [Column("user_auth")]
        public string Auth { get; set; } = string.Empty;

        [Column("donate_tier")]
        public string DonateTier { get; set; } = string.Empty;

        [Column("expire_time")]
        public DateTime? ExpireTime { get; set; }
    }
}
