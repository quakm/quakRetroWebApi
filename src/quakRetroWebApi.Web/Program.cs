using quakRetroWebApi.Infrastructure;
using quakRetroWebApi.Infrastructure.Mapping;
using quakRetroWebApi.Infrastructure.Repositories;
using quakRetroWebApi.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

string externalMappingPath = Path.Combine("D:", "Habbo", "quakRetroWebApi", "mapping", "mapping.json");

if (!File.Exists(externalMappingPath))
{
    throw new FileNotFoundException($"Can't finde Mappingfile at path: {externalMappingPath}");
}


builder.Configuration.AddJsonFile(externalMappingPath, optional: false, reloadOnChange: true);

builder.Services.AddControllers().AddApplicationPart(typeof(Program).Assembly);

builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddSingleton<IMappingService, MappingService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
