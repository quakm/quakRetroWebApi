using quakRetroWebApi.Core.Entities;
using quakRetroWebApi.Infrastructure.Mapping;
using quakRetroWebApi.Infrastructure.Repositories.Interfaces;
using quakRetroWebApi.Infrastructure;
using Dapper;
using System.Data.Common;
using System.Text;

namespace quakRetroWebApi.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly IMappingService _mappingService;
    private readonly EntityMapping _userMapping;
    private readonly EntityMapping _userSettingMapping;

    public UserRepository(DatabaseContext dbContext, IMappingService mappingService)
    {
        (_dbContext, _mappingService) = (dbContext, mappingService);
        _userMapping = mappingService.GetMapping("User");
        _userSettingMapping = mappingService.GetMapping("UserSettings");
    }

    public async Task<UserEntity?> GetUserByIdAsync(int id)
    {
        var userColumns = string.Join(", ", _userMapping.Columns
            .Where(x => x.Key != "Id")
            .Select(c => $"{_userMapping.Alias}.{c.Value} AS {c.Key}"));

        var settingsColumns = string.Join(", ", _userSettingMapping.Columns
            .Where(x => x.Key != "UserId")
            .Select(c => $"{_userSettingMapping.Alias}.{c.Value} AS {c.Key}"));

        var query = new StringBuilder();
        query.AppendLine("SELECT");
        query.AppendLine($"{_userMapping.Alias}.{_userMapping.Columns["Id"]} AS Id,");
        query.AppendLine($"{userColumns},");
        query.AppendLine($"{_userSettingMapping.Alias}.{_userSettingMapping.Columns["UserId"]} AS UserId,");
        query.AppendLine($"{settingsColumns}");
        query.AppendLine($"FROM {_userMapping.TableName} AS {_userMapping.Alias}");
        query.AppendLine($"LEFT JOIN {_userSettingMapping.TableName} AS {_userSettingMapping.Alias}");
        query.AppendLine($"ON {_userMapping.Alias}.{_userMapping.Columns["Id"]} = {_userSettingMapping.Alias}.{_userSettingMapping.Columns["UserId"]}");
        query.AppendLine($"WHERE {_userMapping.Alias}.{_userMapping.Columns["Id"]} = @Id");

        using var connection = _dbContext.CreateConnection();
        var result = await connection.QueryAsync<UserEntity, UserSettingsEntity, UserEntity>(
            query.ToString(),
            (user, settings) =>
            {
                user.UserSettings = settings;
                return user;
            },
            new { Id = id },
            splitOn: "UserId"
        );

        return result.SingleOrDefault();
    }
}