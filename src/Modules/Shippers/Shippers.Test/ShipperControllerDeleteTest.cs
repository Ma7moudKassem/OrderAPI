namespace Shippers.Test;

public class ShipperControllerDeleteTest
{
    readonly ShippersController _controller;
    public ShipperControllerDeleteTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new ShippersController(mediator.Object);
    }
}
