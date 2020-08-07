using System;
using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Order");
        }
        
        public IActionResult AddOrder(Order order)
        {
            order.Id ??= Guid.NewGuid();
            return Ok(BL.BL.Instance.AddOrder(order));
        }
        
        public IActionResult GetOrder(Guid id)
        {
            return Ok(BL.BL.Instance.GetOrderById(id));
        }

        public IActionResult GetAllOrder()
        {
            return Ok(BL.BL.Instance.GetAllOrder());
        }
        
        public IActionResult EditOrder(Order order)
        {
            return Ok(BL.BL.Instance.UpdateOrder(order));
        }

        public IActionResult DeleteOrder(Order order)
        {
            BL.BL.Instance.DeleteOrder(order);
            return Ok("Order deleted");
        }
    }
}