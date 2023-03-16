namespace OrdersDetails.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrdersDetailsApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}