namespace Customers.Test;

public class CustomersControllerPostTest
{
    readonly CustomersController _controller;
    public CustomersControllerPostTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new CustomersController(mediator.Object);
    }

    [Fact]
    public async Task Post_And_ReturnOk()
    {
        Customer customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Mahmoud",
            CompanyName = "StateLabs",
            ContactName = "Kassem",
            ContactTitle = "Software Engineer",
            Address = "Ali Elmahy Street",
            City = "Tanta",
            Region = "Egypt",
            PostalCold = "12",
            Country = "Egypt",
            Phone = "01224176036",
            Fax = "12323432",
        };
        IActionResult oKResult = await _controller.Post(customer);

        Assert.IsType<OkObjectResult>(oKResult as OkObjectResult);
    }

    [Fact]
    public async Task PostBulk_And_ReturnOk()
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Ahmed",
                CompanyName = "StateLabs",
                ContactName = "Kassem",
                ContactTitle = "Software Engineer",
                Address = "Ali Elmahy Street",
                City = "Tanta",
                Region = "Egypt",
                PostalCold = "12",
                Country = "Egypt",
                Phone = "01224176036",
                Fax = "12323432",
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Mohamed",
                CompanyName = "StateLabs",
                ContactName = "Kassem",
                ContactTitle = "Software Engineer",
                Address = "Ali Elmahy Street",
                City = "Tanta",
                Region = "Egypt",
                PostalCold = "12",
                Country = "Egypt",
                Phone = "01224176036",
                Fax = "12323432",
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "ebrahime",
                CompanyName = "StateLabs",
                ContactName = "Kassem",
                ContactTitle = "Software Engineer",
                Address = "Ali Elmahy Street",
                City = "Tanta",
                Region = "Egypt",
                PostalCold = "12",
                Country = "Egypt",
                Phone = "01224176036",
                Fax = "12323432",
            },
        };
        IActionResult oKResult = await _controller.Post(customers);

        Assert.IsType<OkObjectResult>(oKResult as OkObjectResult);
    }

    [Fact]
    public async Task PostBulkInValid_And_ReturnBadRequest()
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Mohamed",
                CompanyName = "StateLabs",
                ContactName = "Kassem",
                ContactTitle = "Software Engineer",
                Address = "Ali Elmahy Street",
                City = "Tanta",
                Region = "Egypt",
                PostalCold = "12",
                Country = "Egypt",
                Phone = "01224176036",
                Fax = "12323432",
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Mohamed",
                CompanyName = "StateLabs",
                ContactName = "Kassem",
                ContactTitle = "Software Engineer",
                Address = "Ali Elmahy Street",
                City = "Tanta",
                Region = "Egypt",
                PostalCold = "12",
                Country = "Egypt",
                Phone = "01224176036",
                Fax = "12323432",
            }
        };
        IActionResult BadRequest = await _controller.Post(customers);

        Assert.IsType<OkObjectResult>(BadRequest as OkObjectResult);
    }
}