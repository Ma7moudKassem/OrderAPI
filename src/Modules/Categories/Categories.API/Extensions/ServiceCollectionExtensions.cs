namespace Categories.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCategoriesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCategoriesApplication()
                .AddCategoriesInfrastructure(configuration);

        return services;
    }
}
