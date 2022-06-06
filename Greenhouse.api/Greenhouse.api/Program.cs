using Greenhouse.api.Models;
using Greenhouse.api.Repositories.Implementations;
using Greenhouse.api.Repositories.Interfaces;
using Greenhouse.api.Services.Implementations;
using Greenhouse.api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<GreenhouseDatabaseSettings>(
    builder.Configuration.GetSection(GreenhouseDatabaseSettings.Name));

//builder.Services.AddSingleton<ReadingService>();
//builder.Services.AddSingleton<SensorService>();

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
