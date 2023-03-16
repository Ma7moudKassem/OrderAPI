namespace Orders.Test;

public class OrderControllerPostTest
{
    readonly OrdersController _controller;
    public OrderControllerPostTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new OrdersController(mediator.Object);
    }
}