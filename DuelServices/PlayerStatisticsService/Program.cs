using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HttpClientService;
using Microsoft.EntityFrameworkCore;
using PlayerStatisticsService.Configurations;
using PlayerStatisticsService.Repositories.Implementations;
using PlayerStatisticsService.Repositories.Interfaces;
using RegistrationService.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IHttpClientService, HttpClientService.HttpClientService>(); // Add HttpClientService
// Register IHttpClientFactory
builder.Services.AddHttpClient();
builder.Services.AddScoped<IPlayerStatisticRepository, PlayerStatisticRepository>();
builder.Services.AddDbContextFactory<PlayerStatisticDbContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 27))));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapControllers();

app.Run();