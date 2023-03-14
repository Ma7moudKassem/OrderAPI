namespace Employees.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEmployeesApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}