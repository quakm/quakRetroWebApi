using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure.Mapping;

public class MappingService(IConfiguration configuration) : IMappingService
{
    private readonly IConfiguration _configuration = configuration;

    public Task<Dictionary<string, string>> GetMappingAsync(string entityName)
    {
        var mapping = new Dictionary<string, string>
        {
            ["TableName"] = _configuration[$"Mapping:{entityName}:TableName"] ?? string.Empty,
            ["Id"] = _configuration[$"Mapping:{entityName}:Id"] ?? string.Empty,
            ["Username"] = _configuration[$"Mapping:{entityName}:Username"] ?? string.Empty,
            ["Email"] = _configuration[$"Mapping:{entityName}:Email"] ?? string.Empty,
        };

        return Task.FromResult(mapping);
    }
}

