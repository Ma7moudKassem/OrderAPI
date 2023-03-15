namespace OrderAPI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharedInfrastructure(configuration);

        services.AddCustomersModule(configuration)
                .AddEmployeesModule(configuration)
                .AddIdentityModule(configuration)
                .AddOrdersModule(configuration);

        return services;
    }
}
