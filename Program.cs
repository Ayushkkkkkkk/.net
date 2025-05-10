using Microsoft.EntityFrameworkCore;
using TravelAgencyApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Register MVC and EF Core with SQL Server
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles(); // For serving uploaded tour images if needed

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

