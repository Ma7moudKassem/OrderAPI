namespace Shared.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
    {
        services.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        });

        services.AddSwaggerService();

        return services;
    }

    public static IServiceCollection AddDatabaseContexts<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        string? connectionString = configuration.GetConnectionString("AppConnectionString");

        services.AddDbContext<T>(e => e.UseSqlServer(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));

        using (IServiceScope scope = services.BuildServiceProvider().CreateScope())
        {
            T dbContext = scope.ServiceProvider.GetRequiredService<T>();

            dbContext.Database.Migrate();
        }

        return services;
    }

    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "OrderAPI",
                Contact = new OpenApiContact
                {
                    Name = "Mahmoud Kassem",
                    Email = "www.modykassem123@gmail.com",
                    Url = new Uri("https://www.googlle.com"),
                },
                License = new OpenApiLicense
                {
                    Name = "OpenGl",
                    Url = new Uri("https://www.googlle.com"),
                }
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter you JWT key",
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new string[]{ }
                }
            });
        });
        return services;
    }
}
