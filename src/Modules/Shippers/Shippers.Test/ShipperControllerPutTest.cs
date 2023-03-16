namespace Shippers.Test;

public class ShipperControllerPutTest
{
    readonly ShippersController _controller;
    public ShipperControllerPutTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new ShippersController(mediator.Object);
    }
}