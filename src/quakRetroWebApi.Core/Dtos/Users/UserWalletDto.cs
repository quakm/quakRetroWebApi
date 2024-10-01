using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Core.Dtos.Users;

public record UserWalletDto
{
    public int Credits { get; set; }
    public int Pixels { get; set; }
    public int Points { get; set; }
}
