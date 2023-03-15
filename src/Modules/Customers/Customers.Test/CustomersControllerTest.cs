using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;

namespace Customers.Test
{
    public class CustomersControllerTest
    {
        readonly CustomersController _controller;
        public CustomersControllerTest()
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
        public async Task Get_WhenCalled_ReturnOk()
        {
            IActionResult okResult = await _controller.Get();

            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async Task GetById_UnknownId_ReturnNotFound()
        {
            IActionResult notFoundResult = await _controller.GetById(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async Task DeleteByIdValid_And_ReturnOk()
        {
            IActionResult oKResult = await _controller.Delete(new Guid("5c2c16a3-f985-473f-9ae1-f3456dee15a6"));

            Assert.IsType<OkObjectResult>(oKResult as OkObjectResult);
        }

        [Fact]
        public async Task DeleteByIdInValid_And_ReturnBadRequest()
        {
            IActionResult notFound = await _controller.Delete(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(notFound as NotFoundResult);
        }
    }
}