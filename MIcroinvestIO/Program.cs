using MIcroinvestIO.Data;
using MIcroinvestIO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MIcroinvestIO.Micro;
using MIcroinvestIO.Services.Interfaces;
using MIcroinvestIO.Services;
using Microsoft.Extensions.Hosting.WindowsServices;
using MIcroinvestIO.Models;

var options = new WebApplicationOptions
{
    Args = args,
    ContentRootPath = WindowsServiceHelpers.IsWindowsService()
                                     ? AppContext.BaseDirectory : default
};

var builder = WebApplication.CreateBuilder(options);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<MultiContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddSingleton<Database>();
builder.Services.AddDbContext<MultiContext>((serviceProvider, options) =>
{
    var dbSettings = serviceProvider.GetRequiredService<Database>();
    options.UseSqlServer(dbSettings.ConnectionString);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<ICashBookService, CashBookService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(3);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddWindowsService();
//builder.Services.AddHostedService<MicroinvestIOService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
