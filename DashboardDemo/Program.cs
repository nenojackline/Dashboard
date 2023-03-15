using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DashboardDemo.Data;
using DashboardDemo.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DashboardDemoContextConnection") ?? throw new InvalidOperationException("Connection string 'DashboardDemoContextConnection' not found.");

builder.Services.AddDbContext<DashboardDemoContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = false)
.AddEntityFrameworkStores<DashboardDemoContext>();


//builder.Services.AddDefaultIdentity<Users>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//}).AddRoles<IdentityRole>()
// .AddEntityFrameworkStores<DashboardDemoContext>()
// .AddDefaultTokenProviders();






// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
