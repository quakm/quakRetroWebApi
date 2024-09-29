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
        var mapping = _configuration.GetSection($"Mapping:{entityName}")
           .GetChildren()
           .ToDictionary(x => x.Key, x => x.Value);

        if (mapping.Count == 0)
            throw new KeyNotFoundException($"Mapping for entity '{entityName}' not found.");

        return Task.FromResult(mapping);
    }
}

