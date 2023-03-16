namespace Employees.Test;

public class EmployeeControllerDeleteTest
{
    readonly EmployeesController _controller;
    public EmployeeControllerDeleteTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new EmployeesController(mediator.Object);
    }
}
