namespace Categories.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCategoriesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContexts<CategoriesDbContext>(configuration);

        services.AddTransient<ICategoriesDbContext, CategoriesDbContext>();

        services.AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<ICategoryUnitOfWork, CategoryUnitOfWork>();

        return services;
    }
}