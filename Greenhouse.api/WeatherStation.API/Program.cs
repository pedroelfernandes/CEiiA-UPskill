using WeatherStation.api.Models;
using WeatherStation.api.Repositories.Implementation;
using WeatherStation.api.Repositories.Interface;
using WeatherStation.api.Services.Implementations;
using WeatherStation.api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<WeatherStationDatabaseSettings>(
    builder.Configuration.GetSection(WeatherStationDatabaseSettings.Name));

builder.Services.AddSingleton<ReadingService>();
builder.Services.AddSingleton<SensorService>();

builder.Services.AddScoped<IReadingRepository, ReadingRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();

builder.Services.AddScoped<IReadingService, ReadingService>();
builder.Services.AddScoped<ISensorService, SensorService>();


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
