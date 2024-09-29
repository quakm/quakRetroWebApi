using Dapper;
using quakRetroWebApi.Core.Entities;
using quakRetroWebApi.Infrastructure.Mapping;
using quakRetroWebApi.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly IMappingService _mappingService;

    public UserRepository(DatabaseContext dbContext, IMappingService mappingService)
        => (_dbContext, _mappingService) = (dbContext, mappingService);

    public async Task<User> GetUserByIdAsync(int id)
    {
        var mapping = await _mappingService.GetMappingAsync("User");
        var query = $@"
        SELECT 
            {mapping["Id"]} AS Id, 
            {mapping["Username"]} AS Username, 
            {mapping["Email"]} AS Email
        FROM dbo.{mapping["TableName"]} 
        WHERE {mapping["Id"]} = @Id";

        using var connection = _dbContext.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
    }
}