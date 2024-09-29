using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure.Helper;

public class UnixTimestampTypeHandler : SqlMapper.TypeHandler<DateTime>
{
    public override DateTime Parse(object value) 
    {
        if (value is long unixTimestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).UtcDateTime;
        }
        if (value is int intTimestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(intTimestamp).UtcDateTime;
        }
        throw new ArgumentException("Unable to convert to DateTime");
    }

    public override void SetValue(IDbDataParameter parameter, DateTime value)
    {
        parameter.Value = ((DateTimeOffset)value).ToUnixTimeSeconds();
    }
}

