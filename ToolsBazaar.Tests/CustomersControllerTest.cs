using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.OrderAggregate;
using ToolsBazaar.Web.Controllers;

namespace ToolsBazaar.Tests
{
    public class CustomersControllerTest
    {
        private readonly IOrderRepository _orderRepository = Substitute.For<IOrderRepository>();
        private readonly ICustomerRepository _customerRepository = Substitute.For<ICustomerRepository>();
        private readonly ILogger<CustomersController> _logger = Substitute.For<ILogger<CustomersController>>();
        private readonly CustomersController _customerController;

        public CustomersControllerTest()
        {
            _customerController = new CustomersController(_logger, _customerRepository, _orderRepository);
        }

        [Fact]
        public void GetTopFiveCustomers_ExpectedToReturn_OkStatusCode200()
        {
            //Arrange
            var startDate = new DateTime(2015, 1, 1);
            var endDate = new DateTime(2022, 12, 31);
            _orderRepository.GetOrdersByGivenStartAndEndDate(startDate, endDate).Returns(MockData.GetOrders());

            //Act
            var result = _customerController.GetTopFiveCustomers();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            ((OkObjectResult)result).StatusCode.Should().Be(200);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsAssignableFrom<IEnumerable<Customer>>(okResult.Value);
            Assert.Equal(4, output.Count());

        }
    }
}
