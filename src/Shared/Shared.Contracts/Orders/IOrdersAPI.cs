namespace Shared.Contracts;

public interface IOrdersAPI
{
    [Get("/Orders/{id}")]
    public Task<OrderDTO> GetOrderById(Guid id);
}