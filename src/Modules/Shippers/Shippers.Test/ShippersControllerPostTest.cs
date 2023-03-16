namespace Shippers.Test;

public class ShippersControllerPostTest
{
    readonly ShippersController _controller;
    public ShippersControllerPostTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new ShippersController(mediator.Object);
    }
}