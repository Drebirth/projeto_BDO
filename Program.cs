using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;
using projetoBDO.Repository;
using projetoBDO.Repository.Interfaces;
using projetoBDO.Repository.Spots;
using projetoBDO.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//SQLite
builder.Services.AddDbContext<BdoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("RequireAdmin", policy =>
//    policy.RequireClaim("PERMISSAO", "ADMIN"));
//});

// roles
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("ADMIN"));
});

//SQL SERVER
//builder.Services.AddDbContext<BdoContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<BdoContext>();
builder.Services.AddScoped<ISpotRepository, SpotRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<SpotService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.HttpOnly = true; // HttpOnly evita que o cookie seja acessado via JavaScript
    options.Cookie.Name = "AspNetCore.Cookies";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
    options.SlidingExpiration = true;
});

var app = builder.Build();

 //Configure the HTTP request pipeline.
 if (!app.Environment.IsDevelopment())
 {
     app.UseExceptionHandler("/Home/Error");
     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
     app.UseHsts();
 }
//if (app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}


// App j� est� pronto para ser executado
// se cometada a aplicacao mesmo rodando em release pelo vs ele pega o banco de dados da raiz e nao da bin?
app.Configuration.GetValue<string>("Env");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
