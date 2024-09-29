using quakRetroWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserEntity?> GetUserByIdAsync(int id);
}

