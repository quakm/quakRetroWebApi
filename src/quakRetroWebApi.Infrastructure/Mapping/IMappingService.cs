﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure.Mapping;

public interface IMappingService
{
    EntityMapping GetMapping(string entityName);
}
