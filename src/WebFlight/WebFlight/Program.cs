using Microsoft.EntityFrameworkCore;
using WebFlight.Components;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;
using WebFlightInfrastructure;
using WebFlightInfrastructure.Entities;
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
builder.Services.AddScoped<IBusinessService<Airport>, AirportService>();
builder.Services.AddScoped<IBusinessService<Flight>, FlightService>();
builder.Services.AddScoped<IBusinessService<Plane>, AirplaneService>();
builder.Services.AddScoped<AirportComponent>();
builder.Services.AddScoped<AirplaneComponent>();

var app = builder.Build();

using (var i = app.Services.CreateScope())
{
    var dbContext = i.ServiceProvider.GetService(typeof(FlightDatabase)) as FlightDatabase;
    var planeBoeing = new PlaneEntity()
    {
        Name = "Boeing X",
        Speed = 500,
        TakeoffDuration = new TimeOnly(0, 5),
        TakeoffEffort = 3,
        FuelConsumption = 5
    };
    var casaAirport = new AirportEntity()
    {
        Name = "Casablanca",
        Latitude = 33.370105013882075,
        Longitude = -7.584463116983734
    };
    var tangierAirport = new AirportEntity()
    {
        Name = "Tanger",
        Latitude = 35.7262693597002,
        Longitude = -5.912900916903573
    };

    dbContext.Airports.Add(casaAirport);
    dbContext.Airports.Add(tangierAirport);
    dbContext.Planes.Add(planeBoeing);
    dbContext.SaveChanges();
}

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