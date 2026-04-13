using CarRental.Application;
using CarRental.Dal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VehicleDBContext>(options =>
    options.UseInMemoryDatabase("CarRentalDb"));


//options.UseSqlServer(Server:your connection string here\\SQLEXPRESS: Database=RentalDB, Trusted_Connection; TrustServerCertificate=True;", b=> b.MigrationsAssembly("CarRent.WebApp)
builder.Services.AddTransient<VehicleDBService>();

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
