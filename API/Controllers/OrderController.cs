using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<IActionResult> AddOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            order.Id ??= Guid.NewGuid();
            return Ok(await BL.BL.Instance.AddOrder(order));
        }
        
        public async Task<IActionResult> GetOrder(Guid id)
        {
            return Ok(await BL.BL.Instance.GetOrderById(id));
        }

        public async Task<IActionResult> GetAllOrder()
        {
            return Ok(await BL.BL.Instance.GetAllOrder());
        }
        
        public async Task<IActionResult> EditOrder(Order order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetOrderById(order.Id) == null) return NotFound("Order not Found");
            return Ok(await BL.BL.Instance.UpdateOrder(order));
        }

        public async Task<IActionResult> DeleteOrder(Order order)
        {
            if (await BL.BL.Instance.GetOrderById(order.Id) == null) return NotFound("Order not Found");
            BL.BL.Instance.DeleteOrder(order);
            return Ok("Order deleted");
        }
    }
}