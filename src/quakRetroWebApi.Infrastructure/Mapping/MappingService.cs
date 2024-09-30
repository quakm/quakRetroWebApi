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

    //public Dictionary<string, string> GetMapping(string entityName)
    //{
    //    var entitySection = _configuration.GetSection($"Mapping:{entityName}");

    //    if (!entitySection.Exists())
    //        throw new KeyNotFoundException($"Mapping for entity '{entityName}' not found.");

    //    var result = new Dictionary<string, string>();

    //    // Add TableName and Alias
    //    result["TableName"] = entitySection["TableName"];
    //    result["Alias"] = entitySection["Alias"];

    //    // Process Columns
    //    var columnsSection = entitySection.GetSection("Columns");
    //    foreach (var column in columnsSection.GetChildren())
    //    {
    //        result[column.Key] = column.Value;
    //    }

    //    if (result.Count <= 2) // Only TableName and Alias were added
    //        throw new InvalidOperationException($"No column mappings found for entity '{entityName}'.");

    //    return result;
    //}

    public EntityMapping GetMapping(string entityName)
    {
        var entitySection = _configuration.GetSection($"Mapping:{entityName}");

        if (!entitySection.Exists())
            throw new KeyNotFoundException($"Mapping for entity '{entityName}' not found.");

        var result = new EntityMapping
        {
            TableName = entitySection["TableName"],
            Alias = entitySection["Alias"],
            Columns = new Dictionary<string, string>()
        };

        var columnsSection = entitySection.GetSection("Columns");
        foreach (var column in columnsSection.GetChildren())
        {
            result.Columns[column.Key] = column.Value;
        }

        if (result.Columns.Count == 0)
            throw new InvalidOperationException($"No column mappings found for entity '{entityName}'.");

        return result;
    }
}

