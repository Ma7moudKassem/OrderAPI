namespace Orders.Test;

public class OrderControllerDeleteTest
{
    readonly OrdersController _controller;
    public OrderControllerDeleteTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new OrdersController(mediator.Object);
    }
}
