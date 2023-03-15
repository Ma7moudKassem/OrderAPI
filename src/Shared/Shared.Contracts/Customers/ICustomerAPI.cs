namespace Shared.Contracts;

public interface ICustomerAPI
{
    [Get("/Customers/{id}")]
    public Task<CustomerDTO> GetCustomer(Guid id);
}