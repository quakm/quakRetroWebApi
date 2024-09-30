using quakRetroWebApi.Core.Entities;
using quakRetroWebApi.Infrastructure.Mapping;
using quakRetroWebApi.Infrastructure.Repositories.Interfaces;
using quakRetroWebApi.Infrastructure;
using Dapper;

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
        var userColumns = string.Join(",", _userMapping.Columns.Where(x => x.Key != "UserId").Select(c => $"{_userMapping.Alias}.{c.Value} AS {c.Key}"));
        var settingsColumns = string.Join(",", _userSettingMapping.Columns.Select(c => $"{_userSettingMapping.Alias}.{c.Value} AS {c.Key}"));

        var query = $@"SELECT u.id AS UserId, {userColumns}, {settingsColumns}
        FROM {_userMapping.TableName} AS {_userMapping.Alias}
        LEFT JOIN {_userSettingMapping.TableName} AS {_userSettingMapping.Alias} 
            ON {_userMapping.Alias}.{_userMapping.Columns["Id"]} = {_userSettingMapping.Alias}.{_userSettingMapping.Columns["UserId"]}
        WHERE {_userMapping.Alias}.{_userMapping.Columns["Id"]} = @Id";

        //var query = $@"
        //SELECT u.id AS UserId, u.username AS Username, u.credits AS Credits, us.id AS Id, us.user_id AS UserId, us.credits AS Credits, us.daily_respect_points AS DailyRespectPoints
        //FROM users AS u
        //LEFT JOIN users_settings AS us
        //    ON u.id = us.user_id
        //WHERE u.id = @Id";

        var x = query.ToString();

        using var connection = _dbContext.CreateConnection();
        var result = await connection.QueryAsync<UserEntity, UserSettingsEntity, UserEntity>(
            query,
            (user, settings) =>
            {
                user.UserSettings = settings;
                return user;
            },
            new { Id = id },
            splitOn: $"UserId"
        );

        return result.SingleOrDefault();
    }
}