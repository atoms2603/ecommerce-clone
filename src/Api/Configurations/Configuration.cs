using Application;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class Configuration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services
               .AddEndpointsApiExplorer()
               .AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Automatically register MediatR and all command/query handlers in the assembly
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(BaseCommandHandler<,>).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(BaseQueryHandler<,>).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(BaseQuery<>).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(BaseCommand<>).Assembly);
        });

        // Automatically register all repositories that inherit from BaseRepository<>
        builder.Services.Scan(scan => scan
        .FromAssembliesOf(typeof(IBaseRepository<>))
        .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddControllers();
    }

    public static void RegisterMiddlewares(this WebApplication app)
    {
        app.UseSwagger()
           .UseSwaggerUI();
        app.MapControllers();
    }
}