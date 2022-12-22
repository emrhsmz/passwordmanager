using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using passwordmanager.Business.Abstract;
using passwordmanager.Business.Concrete;
using passwordmanager.DataAccess.Abstract;
using passwordmanager.DataAccess.Concrete.EntityFramework;
using passwordmanager.WebUI.Data;
using passwordmanager.WebUI.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

#region Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
    options.ExcludedHosts.Add("ekmensocks.com");
    options.ExcludedHosts.Add("www.ekmensocks.com");
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; // say�sa�l de�er
    options.Password.RequireLowercase = true; // k���k karakter
    options.Password.RequiredLength = 6; // minumum ka� karakter
    options.Password.RequireNonAlphanumeric = true; // Alfanumerik zorunlu
    options.Password.RequireUppercase = true; // b�y�k karakter

    options.Lockout.MaxFailedAccessAttempts = 5; // ka� kere yanl�� girme hakk� olsun
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // 5 dk kullan��c� kilitlendi
    options.Lockout.AllowedForNewUsers = true; // yeni kullan�c� i�in kilit i�lemi aktif olsun

    options.User.AllowedUserNameCharacters = ""; // Kullan�c� ad�nda ge�erli olan karakterleri belirtiyoruz.
    options.User.RequireUniqueEmail = true; // ayn� mail adresi ile �yelikolu�maz
    options.SignIn.RequireConfirmedEmail = false; // mail adresine onay gidecek
    options.SignIn.RequireConfirmedPhoneNumber = false; // telefonla onaylamak i�in
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true; //default 20 dk cookie s�resi 
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".passwordmamager.Security.Cookie",
        SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict // CROSS ATAKLARINI ENGELLER - ba�ka kullan�c� cookie al�p servere g�nderemez
    };
});
#endregion

#region Dependency Injection
builder.Services.AddScoped<IFavoriteRepository, EfFavoriteRepository>();
builder.Services.AddScoped<IAccountPropertyRepository, EfAccountPropertyRepository>();
builder.Services.AddScoped<IPlatformRepository, EfPlatformRepository>();
builder.Services.AddScoped<ISafeRepository, EfSafeRepository>();
builder.Services.AddScoped<ISystemTypeRepository, EfSystemTypeRepository>();

builder.Services.AddScoped<IFavoriteService, FavoriteManager>();
builder.Services.AddScoped<IAccountPropertyService, AccountPropertyManager>();
builder.Services.AddScoped<IPlatformService, PlatformManager>();
builder.Services.AddScoped<ISafeService, SafeManager>();
builder.Services.AddScoped<ISystemTypeService, SystemTypeManager>();

#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(UserProfile));
#endregion

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
