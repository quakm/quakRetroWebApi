using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure.Mapping;

public class EntityMapping
{
    public string TableName { get; set; }
    public string Alias { get; set; }
    public Dictionary<string, string> Columns { get; set; }
}
