using WeatherStation.api.Models;
using WeatherStation.api.Repositories;
using WeatherStation.api.Repositories.Interfaces;
using WeatherStation.api.Services;
using WeatherStation.api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<WeatherStationDatabaseSettings>(
    builder.Configuration.GetSection(WeatherStationDatabaseSettings.Name));

builder.Services.AddSingleton<WeatherStationService>();
builder.Services.AddScoped<IReadingRepository, ReadingRepositoryV2>();
builder.Services.AddScoped<IReadingService, ReadingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
