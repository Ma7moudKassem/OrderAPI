namespace Customers.Test;

public class CustomerControllerPutTest
{
    readonly CustomersController _controller;
    public CustomerControllerPutTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new CustomersController(mediator.Object);
    }
}