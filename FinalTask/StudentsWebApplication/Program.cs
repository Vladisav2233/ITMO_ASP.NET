using Microsoft.EntityFrameworkCore;
using Students.Data;
using StudentsWebApplication.Services.Impl;
using StudentsWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();

builder.Services.AddDbContext<StudentsWebApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Students"));
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
