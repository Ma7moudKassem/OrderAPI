namespace Employees.Infrastructure;

public class EmployeeRepository : BaseRepository<Employee, IEmployeesDbContext>, IEmployeeRepository
{
    public EmployeeRepository(IEmployeesDbContext context) : base(context) { }
}