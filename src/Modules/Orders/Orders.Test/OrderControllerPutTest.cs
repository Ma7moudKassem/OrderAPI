namespace Orders.Test;

public class OrderControllerPutTest
{
    readonly OrdersController _controller;
    public OrderControllerPutTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new OrdersController(mediator.Object);
    }
}