using Microsoft.EntityFrameworkCore;
using PortfolioManager.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<PortfolioManagerContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("Db")));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration.GetConnectionString("Redis");
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

Console.WriteLine("Migration started.");

using var serviceScope = app.Services.CreateScope();
var context = serviceScope.ServiceProvider.GetRequiredService<PortfolioManagerContext>();
context.Database.Migrate();

Console.WriteLine("Migration applied.");

app.Run();