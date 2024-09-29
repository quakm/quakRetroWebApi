using Dapper;
using quakRetroWebApi.Core.Entities;
using quakRetroWebApi.Infrastructure.Mapping;
using quakRetroWebApi.Infrastructure.Repositories.Interfaces;

namespace quakRetroWebApi.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly IMappingService _mappingService;

    public UserRepository(DatabaseContext dbContext, IMappingService mappingService)
        => (_dbContext, _mappingService) = (dbContext, mappingService);

    public async Task<UserEntity?> GetUserByIdAsync(int id)
    {
        var mapping = await _mappingService.GetMappingAsync("User");

        var filteredMapping = mapping.Where(item => item.Key != "TableName" && item.Key != "Id");
        var queryBody = string.Join(",\n", filteredMapping.Select(item => $"{item.Value} AS {item.Key}"));

        var query = $@"
        SELECT 
            {mapping["Id"]} AS Id,
            {queryBody}
        FROM {mapping["TableName"]} 
            WHERE {mapping["Id"]} = @Id";

        using var connection = _dbContext.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<UserEntity>(query, new { Id = id });
    }


}