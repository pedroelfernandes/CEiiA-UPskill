using MainAPI.Data;
using MainAPI.Repositories.Implementations;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Implementations;
using MainAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
