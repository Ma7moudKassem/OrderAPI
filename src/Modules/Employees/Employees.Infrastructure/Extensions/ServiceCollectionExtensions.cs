namespace Employees.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEmployeesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContexts<EmployeesDbContext>(configuration);

        services.AddTransient<IEmployeesDbContext, EmployeesDbContext>();

        services.AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<IEmployeeUnitOfWork, EmployeeUnitOfWork>();

        return services;
    }
}