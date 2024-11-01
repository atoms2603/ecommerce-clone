using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectString = "Server=localhost;Port=55432;Database=AppDb;User Id=postgres;Password=zaQ@1234";
    options.UseNpgsql(connectString,
        b =>
        {
            b.MigrationsAssembly("Api");
            b.CommandTimeout(1200);
        }
    );
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.EnableDetailedErrors();
}, ServiceLifetime.Transient);

var app = builder.Build();

app.RegisterMiddlewares();

await app.RunAsync();


