using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Shop.ApplicationServices.Services;
using Shop.ApplicationServices.Services.EmailService;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Microsoft.AspNetCore.Identity;
using Shop.Models.Hubs;
using Shop.Core.Domain;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

// Add other services...

builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ShopContext>();


builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddScoped<IRealEstateServices, RealEstatesServices>();
builder.Services.AddScoped<IKindergartenServices, KinderGartenServices>();
builder.Services.AddScoped<IWheatherForecastServices, WheatherForecastServices>();
builder.Services.AddScoped<ICackNorisServices, ChackNorisServices>();
builder.Services.AddScoped<ICoctailServices, CoctailServices>();
builder.Services.AddScoped<IAcuWeatherServices, AcuWeatherServices>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 3;

    options.Lockout.MaxFailedAccessAttempts = 2;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
    .AddEntityFrameworkStores<ShopContext>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
    .AddDefaultUI();

//builder.Services.AddScoped<IIdentityService, IdentityService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath = "/multipleFileUpload"
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapHub<ChatHub>("/ChatHub/chat");

app.Run();

