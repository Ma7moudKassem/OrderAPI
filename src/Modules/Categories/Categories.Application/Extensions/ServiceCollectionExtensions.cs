namespace Categories.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCategoriesApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}