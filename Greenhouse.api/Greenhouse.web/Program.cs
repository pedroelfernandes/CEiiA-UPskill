
using Greenhouse.web.Services.Implementations;
using Greenhouse.web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//configure data and connection string
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(
//    builder.Configuration.GetConnectionString("GreenhouseDBConnection")));

builder.Services.AddScoped<ISensorServices, SensorServices>();
builder.Services.AddScoped<ISensorTypeServices, SensorTypeServices>();
builder.Services.AddScoped<IAssetServices, AssetServices>();
builder.Services.AddScoped<IAssetTypeServices, AssetTypeServices>();
builder.Services.AddScoped<IAPIUserServices, APIUserServices>();
builder.Services.AddScoped<IRolesServices, RolesServices>();
builder.Services.AddScoped<IReadingServices, ReadingServices>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
