﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure;

public class DatabaseContext
{
    private readonly string _connectionString;

    public DatabaseContext(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");

    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);

}

