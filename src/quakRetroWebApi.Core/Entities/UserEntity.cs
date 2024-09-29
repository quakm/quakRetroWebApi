using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Core.Entities;
public class UserEntity
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string RealName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int EmailVerified { get; set; }
    public string Motto { get; set; }
    public string Look { get; set; }
    public char Gender { get; set; }
    public int Rank { get; set; }
    public int Credits { get; set; }
    public int Pixels { get; set; }
    public int Points { get; set; }
    public int Online { get; set; }
    public string AuthTicket { get; set; }
    public string IpRegister { get; set; }
    public string IpCurrent { get; set; }
    public string MachineId { get; set; }
    public int HomeRoom { get; set; }
    public string SecretKey { get; set; }
    public string Pincode { get; set; }
    public int? ExtraRank { get; set; }

    public DateTime AccountCreated { get; set; } = DateTime.MinValue;
    public DateTime AccountDayOfBirth { get; set; } = DateTime.MinValue;
    public DateTime LastLogin { get; set; } = DateTime.MinValue;
    public DateTime LastOnline { get; set; } = DateTime.MinValue;

}

