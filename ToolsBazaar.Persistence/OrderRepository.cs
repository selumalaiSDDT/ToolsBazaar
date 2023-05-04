﻿using ToolsBazaar.Domain.OrderAggregate;

namespace ToolsBazaar.Persistence;

public class OrderRepository : IOrderRepository
{
    public IEnumerable<Order> GetAll() => DataSet.AllOrders;

    public IEnumerable<Order> GetOrdersByGivenStartAndEndDate(DateTime startDate, DateTime endDate)
    {
        return DataSet.AllOrders.Where(order => order.Date >= startDate && order.Date <= endDate).ToList();
    }
}