namespace OrderAPI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharedInfrastructure();

        services.AddCustomersModule(configuration)
                .AddEmployeesModule(configuration)
                .AddIdentityModule(configuration)
                .AddOrdersModule(configuration);

        return services;
    }
}
