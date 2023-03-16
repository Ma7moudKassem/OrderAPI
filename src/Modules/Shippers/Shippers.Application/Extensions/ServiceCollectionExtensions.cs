namespace Shippers.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddShippersApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}