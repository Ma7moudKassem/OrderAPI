namespace OrdersDetails.Test;

public class OrdersDetailControllerDeleteTest
{
    readonly OrdersDetailsController _controller;
    public OrdersDetailControllerDeleteTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new OrdersDetailsController(mediator.Object);
    }
}
