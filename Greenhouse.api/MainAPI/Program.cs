using MainAPI.Data;
using MainAPI.Helpers.Implementations;
using MainAPI.Helpers.Interfaces;
using MainAPI.Repositories.Implementations;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Implementations;
using MainAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure data and connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("MainAPIConnection")));


//Dependency injection - instanciates class through IClass
builder.Services.AddScoped<IAPIUserRepository, APIUserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorTypeRepository, SensorTypeRepository>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();

builder.Services.AddScoped<IAPIUserService, APIUserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISensorService, SensorService>();    
builder.Services.AddScoped<ISensorTypeService, SensorTypeService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();
builder.Services.AddScoped<ILayerAPISensorService, LayerAPISensorService>();
builder.Services.AddScoped<IReadingService, ReadingService>();

builder.Services.AddScoped<IHttpClHlp, HttpClHlp>();
builder.Services.AddScoped<ILayerAPIJwtToken, LayerAPIJwtToken>();
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
