using Microsoft.AspNetCore.Authentication.Cookies;
using OpenFluency.Repositories;
using OpenFluency.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var connectionString = builder.Configuration.GetConnectionString("OpenFluencyConnectionString");

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(c => new UsuarioRepository(connectionString!));

var app = builder.Build();

//Usando tela de erro customizada mesmo em ambiente de desenvolvimento
app.UseExceptionHandler("/Erro/Index");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{  
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
