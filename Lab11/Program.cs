using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lab11.Data;
using loginDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var roomConnectionString = builder.Configuration.GetConnectionString("RoomConnection") ?? throw new InvalidOperationException("Connection string 'RoomConnection' not found.");

builder.Services.AddDbContext<Lab11.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<loginDemo.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(roomConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Lab11.Data.ApplicationDbContext>(); // Kullanıcı kimlik doğrulaması için ApplicationDbContex'i kullan

builder.Services.AddRazorPages();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login"; // Set the login path
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
