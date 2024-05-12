using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer;
using RepositoryLayer.Concrete;
using RepositoryLayer.Contracts;
using ServiceLayer;
using ServiceLayer.Contracts;
using NewsApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<INewsService, NewsManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IAuthorService, AuthorManager>();

builder.Services.AddControllersWithViews(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<RepositoryContext>();
builder.Services.AddDistributedMemoryCache(); // Session kullanýmý için bellek önbelleði ekleme
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman aþýmý süresi
    options.Cookie.HttpOnly = true; // Tarayýcý dýþýndan eriþimi engelleme
    options.Cookie.IsEssential = true; // Zorunlu çerez iþaretleyicisi ekleme
    options.Cookie.Name = "NewsCookie";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

//builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mssqlslconnection"),
        b => b.MigrationsAssembly("NewsApp"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/Error/ErrorPage", "?code={0}");
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.ConfigureDefaultAdminUser();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute("Admin", "Admin", "Admin/{controller=Default}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
