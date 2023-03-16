namespace Employees.Test;

public class EmployeeControllerPutTest
{
    readonly EmployeesController _controller;
    public EmployeeControllerPutTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new EmployeesController(mediator.Object);
    }
}