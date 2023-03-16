namespace Customers.Test;

public class CustomerControllerDeleteTest
{
    readonly CustomersController _controller;
    public CustomerControllerDeleteTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new CustomersController(mediator.Object);
    }

    [Fact]
    public async Task DeleteValid_and_returnOk()
    {
        IActionResult okResult = await _controller.Delete(new Guid("5c2c16a3-f985-473f-9ae1-f3456dee15a6"));

        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }
}
