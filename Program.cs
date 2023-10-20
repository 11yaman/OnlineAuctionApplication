using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Services;
using OnlineAuctionApplication.Persistence;
using OnlineAuctionApplication.Persistence.Repositories;
using OnlineAuctionApplication.Data;
using OnlineAuctionApplication.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();

// Add AutoMapper scanning (requires AutoMapper package)
builder.Services.AddAutoMapper(typeof(Program));

// db, with dependency injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(
        "ApplicationDbConnection")));
// Identity db
builder.Services.AddDbContext<ApplicationIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(
        "ApplicationIdentityDbConnection")));

builder.Services.AddDefaultIdentity<ApplicationIdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationIdentityContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
