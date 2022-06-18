using Microsoft.IdentityModel.Tokens;
using System.Text;
using WeatherStation.api.JwtHelper;
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


builder.Services.AddScoped<IReadingRepository, ReadingRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();

builder.Services.AddScoped<IReadingService, ReadingService>();
builder.Services.AddScoped<ISensorService, SensorService>();

builder.Services.AddScoped<IJwtToken, JwtToken>();


//const string SECRET_KEY = "Kon4WC3b3yVpkSg2xMFwtMl6qVq7kJJn";

string SECRET_KEY = builder.Configuration.GetValue<string>("SECRET_KEY"); 

SymmetricSecurityKey SIGNING_KEY = new(Encoding.UTF8.GetBytes(SECRET_KEY));

string SSL_URL = builder.Configuration.GetValue<string>("SSL_URL");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", jwtOptions =>
    {
        jwtOptions.TokenValidationParameters = new()
        {
            IssuerSigningKey = SIGNING_KEY,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = SSL_URL,
            ValidAudience = SSL_URL,
            ValidateLifetime = true
        };
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
