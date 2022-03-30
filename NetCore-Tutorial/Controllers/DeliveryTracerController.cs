using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Tutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryTracerController : ControllerBase
    {
        private static readonly List<Order> orders = new List<Order> { 
            new Order{ 
                Id = 1, CustomerName = "Januar", CustomerAddress = "Indonesia", TotalItem = 10, Amount = 1000000, 
                OrderStatuses = new List<OrderStatus>{ 
                    new OrderStatus{ Id = 1, OrderId = 1, StepNumber = 1, StatusName = "Order Place", Description = "We have recieved your order", DateCreated = DateTime.Now.AddMinutes(-35) },
                    new OrderStatus{ Id = 2, OrderId = 1, StepNumber = 2, StatusName = "Order Confirm", Description = "We have confirmed your order", DateCreated = DateTime.Now.AddMinutes(-30) },
                    new OrderStatus{ Id = 3, OrderId = 1, StepNumber = 3, StatusName = "Order Processed", Description = "We have processed your order", DateCreated = DateTime.Now.AddMinutes(-25) },
                    new OrderStatus{ Id = 4, OrderId = 1, StepNumber = 4, StatusName = "Ready to Pickup", Description = "We have ready to pickup your order", DateCreated = DateTime.Now.AddMinutes(-20) },
                    new OrderStatus{ Id = 5, OrderId = 1, StepNumber = 5, StatusName = "Pickup Complete", Description = "Your order is picked up", DateCreated = DateTime.Now.AddMinutes(-15) },
                    new OrderStatus{ Id = 6, OrderId = 1, StepNumber = 6, StatusName = "Out for Delivery", Description = "Your order is on the way", DateCreated = DateTime.Now.AddMinutes(-10) },
                    new OrderStatus{ Id = 7, OrderId = 1, StepNumber = 7, StatusName = "Delivery Completed", Description = "We have completed your order", DateCreated = DateTime.Now.AddMinutes(-5) },
                }
            },
            new Order{
                Id = 2, CustomerName = "Januar 2", CustomerAddress = "Indonesia", TotalItem = 30, Amount = 2000000,
                OrderStatuses = new List<OrderStatus>{
                    new OrderStatus{ Id = 1, OrderId = 2, StepNumber = 1, StatusName = "Order Place", Description = "We have recieved your order", DateCreated = DateTime.Now.AddMinutes(-35) },
                    new OrderStatus{ Id = 2, OrderId = 2, StepNumber = 2, StatusName = "Order Confirm", Description = "We have confirmed your order", DateCreated = DateTime.Now.AddMinutes(-30) },
                    new OrderStatus{ Id = 3, OrderId = 2, StepNumber = 3, StatusName = "Order Processed", Description = "We have processed your order", DateCreated = DateTime.Now.AddMinutes(-25) },
                }
            },
            new Order{
                Id = 3, CustomerName = "Januar 3", CustomerAddress = "Indonesia", TotalItem = 10, Amount = 3000000,
                OrderStatuses = new List<OrderStatus>{
                    new OrderStatus{ Id = 1, OrderId = 3, StepNumber = 1, StatusName = "Order Place", Description = "We have recieved your order", DateCreated = DateTime.Now.AddMinutes(-35) },
                    new OrderStatus{ Id = 2, OrderId = 3, StepNumber = 2, StatusName = "Order Confirm", Description = "We have confirmed your order", DateCreated = DateTime.Now.AddMinutes(-30) },
                    new OrderStatus{ Id = 3, OrderId = 3, StepNumber = 3, StatusName = "Order Processed", Description = "We have processed your order", DateCreated = DateTime.Now.AddMinutes(-25) },
                    new OrderStatus{ Id = 4, OrderId = 3, StepNumber = 4, StatusName = "Ready to Pickup", Description = "We have ready to pickup your order", DateCreated = DateTime.Now.AddMinutes(-20) },
                    new OrderStatus{ Id = 5, OrderId = 3, StepNumber = 5, StatusName = "Pickup Complete", Description = "Your order is picked up", DateCreated = DateTime.Now.AddMinutes(-15) },
                }
            },
            new Order{
                Id = 4, CustomerName = "Januar 4", CustomerAddress = "Indonesia", TotalItem = 10, Amount = 4000000,
                OrderStatuses = new List<OrderStatus>{
                    new OrderStatus{ Id = 1, OrderId = 4, StepNumber = 1, StatusName = "Order Place", Description = "We have recieved your order", DateCreated = DateTime.Now.AddMinutes(-35) },
                    new OrderStatus{ Id = 2, OrderId = 4, StepNumber = 2, StatusName = "Order Confirm", Description = "We have confirmed your order", DateCreated = DateTime.Now.AddMinutes(-30) },
                    new OrderStatus{ Id = 3, OrderId = 4, StepNumber = 3, StatusName = "Order Processed", Description = "We have processed your order", DateCreated = DateTime.Now.AddMinutes(-25) },
                    new OrderStatus{ Id = 4, OrderId = 4, StepNumber = 4, StatusName = "Ready to Pickup", Description = "We have ready to pickup your order", DateCreated = DateTime.Now.AddMinutes(-20) },
                    new OrderStatus{ Id = 5, OrderId = 4, StepNumber = 5, StatusName = "Pickup Complete", Description = "Your order is picked up", DateCreated = DateTime.Now.AddMinutes(-15) },
                    new OrderStatus{ Id = 6, OrderId = 4, StepNumber = 6, StatusName = "Out for Delivery", Description = "Your order is on the way", DateCreated = DateTime.Now.AddMinutes(-10) },
                }
            },
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public DeliveryTracerController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public ActionResult<ResultModel<Order>> Get(int id)
        {
            ResultModel<Order> result = new ResultModel<Order>();

            var data = orders.Where(x => x.Id == id).FirstOrDefault();
            if (data != null) {
                result.SetSuccess("success", data);
            }
            return result;
        }
    }

    public class Order {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int TotalItem { get; set; }
        public decimal Amount { get; set; }

        public ICollection<OrderStatus> OrderStatuses { get; set; }
    }

    public class OrderStatus
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int StepNumber { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
