using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DonatorAPI.Models
{
    [Table("userinfo")]
    public class UserInfo
    {
        [Column("user_id")]
        public int Id { get; set; }

        [Column("user_auth")]
        public string Auth { get; set; } = string.Empty;

        [Column("donate_tier")]
        public string DonateTier { get; set; } = string.Empty;

        [Column("expire_time")]
        public DateTime? ExpireTime { get; set; }
        public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = [];
    }
}
