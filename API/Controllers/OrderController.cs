using System;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : Controller
    {
        public string Index()
        {
            return "Order";
        }
        
        public Order AddKrapfen(Order order)
        {
            order.Id ??= Guid.NewGuid();
            return BL.BL.Instance.AddOrder(order);
        }
    }
}