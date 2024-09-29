using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure.Mapping;

public interface IMappingService
{
    Task<Dictionary<string, string>> GetMappingAsync(string entityName);
}
