namespace OrdersDetails.Test;

public class OrdersDetailsControllerPostTest
{
    readonly OrdersDetailsController _controller;
    public OrdersDetailsControllerPostTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new OrdersDetailsController(mediator.Object);
    }
}