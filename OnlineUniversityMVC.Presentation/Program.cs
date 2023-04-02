using Microsoft.EntityFrameworkCore;
using OnlineUniversityMVC.Infrastructure.Persistence;
using OnlineUniversityMVC.Infrastructure.Extensions;
using OnlineUniversityMVC.Infrastructure.Seeders;
using OnlineUniversityMVC.Application.Extensions;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRewriter(new Microsoft.AspNetCore.Rewrite.RewriteOptions().Add(context =>
{
    if (context.HttpContext.Request.Path == "/?page=%2FHome")
    {
        context.HttpContext.Response.Redirect("/Home");
    }
}));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
