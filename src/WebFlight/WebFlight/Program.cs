using Microsoft.EntityFrameworkCore;
using WebFlight.ViewComponents;
using WebFlightBusiness.Services;
using WebFlightInfrastructure;
using WebFlightInfrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
    options.ViewLocationFormats.Add("/{0}.cshtml");
});
builder.Services.AddDbContextPool<FlightDatabase>(options =>
{
    options.UseInMemoryDatabase(databaseName: "FlightDatabase");
});

builder.Services.AddScoped<AirportRepository>();
builder.Services.AddScoped<FlightRepository>();
builder.Services.AddScoped<AirplaneRepository>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IAirplaneService, AirplaneService>();
builder.Services.AddScoped<AirportViewComponent>();
builder.Services.AddScoped<AirplaneViewComponent>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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