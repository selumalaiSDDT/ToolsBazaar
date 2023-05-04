using Bogus.DataSets;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.OrderAggregate;
using ToolsBazaar.Persistence.ErrorHandling;

namespace ToolsBazaar.Web.Controllers;

public record CustomerDto(string Name);

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(ILogger<CustomersController> logger, ICustomerRepository customerRepository, IOrderRepository orderRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
        _orderRepository = orderRepository; 
    }

    [HttpPut("{customerId:int}")]
    public IActionResult UpdateCustomerName([FromRoute] int customerId, [FromBody] CustomerDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Customer name is not valid, cannot be null or spaces");
            }

            _logger.LogInformation($"Updating customer -> {customerId} in progress...");

            _customerRepository.UpdateCustomerName(customerId, dto.Name);

            return Ok();
        }
        catch (HttpNotFoundException ex)
        {
            _logger.LogWarning(ex.Message);
            Console.WriteLine(ex.Message);

            return NotFound();
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex.Message);
            Console.WriteLine(ex.Message);

            return BadRequest();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return StatusCode(500, "System Error");
        }
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_customerRepository.GetAll());
    }

    [HttpGet("top")]
    public IActionResult GetTopFiveCustomers()
    {
        var startDate = new DateTime(2015, 1, 1);
        var endDate = new DateTime(2022, 12, 31);

        var ordersByDate = _orderRepository.GetOrdersByGivenStartAndEndDate(startDate, endDate);

        if(ordersByDate != null && ordersByDate.Count() > 0)
        {

            var customerTotalSpending = (from orders in ordersByDate
                                         select new
                                         {
                                             totalSpending = orders.Items.Sum(s => s.Price),
                                             customer = orders.Customer
                                         }).
             OrderByDescending(x => x.totalSpending).Take(5).ToList();

            var topFiveCustomer = from topCustomer in customerTotalSpending select topCustomer.customer;
                    

            return Ok(topFiveCustomer);
        }

        _logger.LogInformation("No orders for the given date range");
        Console.WriteLine("No orders for the given date range");
        return Ok();
    }
}