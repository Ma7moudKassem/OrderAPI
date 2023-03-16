namespace Employees.Test;

public class EmployeesControllerPostTest
{
    readonly EmployeesController _controller;
    public EmployeesControllerPostTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new EmployeesController(mediator.Object);
    }
}