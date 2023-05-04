using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.OrderAggregate;
using ToolsBazaar.Domain.ProductAggregate;

namespace ToolsBazaar.Tests
{
    public class MockData
    {
        public static List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Customer   = new Customer{ Id = 1, Name = "Cust 1" },
                    Date       = new DateTime(2017, 1, 1),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Id = 1,Quantity = 25 ,Product = new Product{ Id = 1, Price = 50}},
                        new OrderItem { Id = 2, Quantity = 22, Product = new Product{ Id = 2, Price = 100}},
                        new OrderItem { Id = 3, Quantity = 344, Product = new Product{ Id = 3, Price = 155}}
                    }
                },
               new Order
                {
                    Id = 2,
                    Customer   = new Customer{Id = 2, Name = "Cust 2" },
                    Date       = new DateTime(2018, 1, 1),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Id = 1,Quantity = 20 ,Product = new Product{ Id = 1, Price = 25}},
                        new OrderItem { Id = 2, Quantity = 12, Product = new Product{ Id = 2, Price = 30} },
                        new OrderItem { Id = 3, Quantity = 31, Product = new Product{ Id = 3, Price = 45} }
                    }
                },
                new Order
                {
                    Id = 3,
                    Customer   = new Customer{Id = 3, Name = "Cust 3" },
                    Date       = new DateTime(2021, 1, 1),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Id = 1,Quantity = 2 ,Product = new Product{ Id = 1, Price = 10 }},
                        new OrderItem { Id = 2, Quantity = 1, Product = new Product{ Id = 2, Price = 20} },
                        new OrderItem { Id = 3, Quantity = 4, Product = new Product{ Id = 3, Price = 30} }
                    }
                },
                new Order
                {
                    Id = 4,
                    Customer   = new Customer{Id = 4, Name = "Cust 4" },
                    Date       = new DateTime(2022, 1, 1),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Id = 1,Quantity = 5 ,Product = new Product{ Id = 1, Price = 11 }},
                        new OrderItem { Id = 2, Quantity = 7, Product = new Product{ Id = 2, Price = 22} },
                        new OrderItem { Id = 3, Quantity = 8, Product = new Product{ Id = 3, Price = 33} }
                    }
                }
            };
        }
    }
}
    
