using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DonatorAPI.Models
{
    [Table("purchase_history")]
    public class PurchaseHistory
    {
        [Key]
        [Column("purchase_id")]
        public int Id { get; set; }

        [Column("user_auth")]
        public string Auth { get; set; } = string.Empty;

        [Column("price")]
        public float Price { get; set; }

        [Column("purchase_time")]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("Auth")]
        [JsonIgnore]
        public UserInfo? UserInfo { get; set; }
    }
}
