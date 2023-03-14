namespace Employees.Infrastructure;

public class EmployeeRepository : IEmployeeRepository
{
    readonly IEmployeesDbContext _context;
    public EmployeeRepository(IEmployeesDbContext context)
        => _context = context;

    public async Task<Employee> GetAsync(Guid id) =>
        await _context.Employees.FirstOrDefaultAsync(e => e.Id == id) ?? new();
    public async Task<IEnumerable<Employee>> GetAsync() =>
        await _context.Employees.ToListAsync();
    public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> predicate) =>
        await _context.Employees.Where(predicate).ToListAsync();
   
    public async Task<Employee> AddAsync(Employee employee)
    {
        if (employee is null) throw new ArgumentNullException(nameof(employee) + "is null");

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return employee;
    }
    public async Task<IEnumerable<Employee>> AddAsync(IEnumerable<Employee> employees)
    {
        if (employees is null || !employees.Any())
            throw new ArgumentNullException($"{typeof(Employee).Name}s are null or empty");

        await _context.Employees.AddRangeAsync(employees);
        await _context.SaveChangesAsync();

        return employees;
    }

    public async Task<Employee> EditAsync(Employee employee)
    {
        await CheckParameterIsExistingInDb(employee);

        await Task.Run(() => _context.Employees.Update(employee));
        await _context.SaveChangesAsync();

        return employee;
    }
    public async Task<IEnumerable<Employee>> EditAsync(IEnumerable<Employee> employees)
    {
        await CheckParameterIsExistingInDb(employees);

        await Task.Run(() => _context.Employees.UpdateRange(employees));
        await _context.SaveChangesAsync();

        return employees;
    }

    public async Task RemoveAsync(Guid id)
    {
        Employee employeeFromDb = await GetAsync(id);
        
        await CheckParameterIsExistingInDb(employeeFromDb);

        await Task.Run(() => _context.Employees.Remove(employeeFromDb));
        await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(Employee employee)
    {
        await CheckParameterIsExistingInDb(employee);

        await Task.Run(() => _context.Employees.Remove(employee));
        await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(IEnumerable<Employee> employees)
    {
        await CheckParameterIsExistingInDb(employees);

        await Task.Run(() => _context.Employees.RemoveRange(employees));
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransaction() =>
        await _context.BeginTransaction();
    
    private async Task CheckParameterIsExistingInDb(IEnumerable<Employee> employees)
    {
        IEnumerable<Guid> employeesIds = employees.Select(e => e.Id);
        IEnumerable<Employee> employeesFromDb = await GetAsync(e => employeesIds.Contains(e.Id));

        if (!employeesFromDb.Any() || employeesFromDb.Count() != employees.Count())
            throw new ArgumentNullException($"{typeof(Employee).Name}s are not found in database");
    }
    private async Task CheckParameterIsExistingInDb(Employee employee)
    {
        Employee employeeFromDb = await GetAsync(employee.Id);

        if (employeeFromDb is null || employeeFromDb.Id.Equals(Guid.Empty))
            throw new ArgumentNullException($"{typeof(Employee).Name} is not found in database");
    }
}
