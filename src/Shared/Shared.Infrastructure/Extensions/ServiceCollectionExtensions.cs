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

    public static IServiceCollection AddDatabaseContexts<T>(this IServiceCollection services, IConfiguration configuration) where T : IdentityDbContext
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
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Bearer",
                BearerFormat = "JWT",
                Scheme = "bearer",
                Description = "Specify the authorization token.",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        return services;
    }
}
