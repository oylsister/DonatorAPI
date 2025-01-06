namespace DonatorAPI.Data.Dtos;

public class UserInfoDto
{
    public string Auth { get; set; } = string.Empty;

    public string DonateTier { get; set; } = string.Empty;

    public DateTime? ExpireTime { get; set; }
}
