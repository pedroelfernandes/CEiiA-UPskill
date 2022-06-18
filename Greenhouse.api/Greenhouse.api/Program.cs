using Greenhouse.api.JwtHelper;
using Greenhouse.api.Models;
using Greenhouse.api.Repositories.Implementations;
using Greenhouse.api.Repositories.Interfaces;
using Greenhouse.api.Services.Implementations;
using Greenhouse.api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddScoped<IJwtToken, JwtToken>();

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
