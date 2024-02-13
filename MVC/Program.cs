using Application.Products;
using Application.Services;
using Application.Validators.Products;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructures.Context;
using Infrastructures.Data.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingService));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(typeof(Create));
builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCommandValidator>();

builder.Services.AddDbContext<SamanAryaEcommerceDbContext>(option =>
         option.UseSqlServer(configuration.GetConnectionString("SamanAryaEcommerceDBConnectionString")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
{
    options.SlidingExpiration = true;
    options.LoginPath = "/Auth/Login";
    options.LogoutPath = "/Auth/Logout";
    options.AccessDeniedPath = "/Auth/Login";
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
    var res = await mediator.Send(new Application.Roles.ExistAny.Query());
    if (!res.Value)
    {
        await mediator.Send(new Application.Roles.SeedRoles.Command() { Names = new() { "SuperAdmin", "Admin", "User" } });
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
