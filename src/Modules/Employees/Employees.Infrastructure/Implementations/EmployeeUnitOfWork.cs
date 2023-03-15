namespace Employees.Infrastructure;

public class EmployeeUnitOfWork : BaseUnitOfWork<Employee, IEmployeesDbContext>, IEmployeeUnitOfWork
{
    public EmployeeUnitOfWork(IBaseRepository<Employee, IEmployeesDbContext> repository) : base(repository) { }
}