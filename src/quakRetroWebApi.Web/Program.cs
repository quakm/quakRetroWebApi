using quakRetroWebApi.Infrastructure;
using quakRetroWebApi.Infrastructure.Mapping;
using quakRetroWebApi.Infrastructure.Repositories;
using quakRetroWebApi.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

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
