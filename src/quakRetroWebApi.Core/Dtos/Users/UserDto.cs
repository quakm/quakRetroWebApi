using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Core.Dtos.Users;

public record UserDto
{
    public required int UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }

    public UserBadgesDto? UserBadges { get; set; }
    public UserSettingsDto? UserSettings { get; set; }
    public UserWalletDto? UserWallet { get; set; }
}
