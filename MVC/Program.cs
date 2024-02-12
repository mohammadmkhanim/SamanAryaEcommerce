using Application.Products;
using Application.Services;
using Application.Validators.Products;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructures.Context;
using Infrastructures.Data.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingService));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(typeof(Create));
builder.Services.AddControllersWithViews();
// .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCommandValidator>());
// builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCommandValidator>();

// builder.Services.AddControllersWithViews()
//         .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
// builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddDbContext<SamanAryaEcommerceDbContext>(option =>
         option.UseSqlServer(configuration.GetConnectionString("SamanAryaEcommerceDBConnectionString")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
