namespace Suppliers.Test;

public class SupplierControllerDeleteTest
{
    readonly SuppliersController _controller;
    public SupplierControllerDeleteTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new SuppliersController(mediator.Object);
    }
}
