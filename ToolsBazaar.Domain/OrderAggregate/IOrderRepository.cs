namespace ToolsBazaar.Domain.OrderAggregate;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();

    IEnumerable<Order> GetOrdersByGivenStartAndEndDate(DateTime startDate, DateTime endDate);
}