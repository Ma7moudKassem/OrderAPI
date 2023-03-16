namespace OrdersDetails.Test;

public class OrdersDetailControllerPutTest
{
    readonly OrdersDetailsController _controller;
    public OrdersDetailControllerPutTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new OrdersDetailsController(mediator.Object);
    }
}