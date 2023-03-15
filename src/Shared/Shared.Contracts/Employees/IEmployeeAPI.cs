namespace Shared.Contracts;

public interface IEmployeeAPI
{
    [Get("/Employees/{id}")]
    public Task<EmployeeDTO> GetEmployee(Guid id);
}