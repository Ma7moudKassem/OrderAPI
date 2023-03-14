namespace Employees.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEmployeesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEmployeesApplication()
                .AddEmployeesInfrastructure(configuration);

        return services;
    }
}
