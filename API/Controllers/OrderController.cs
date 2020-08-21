using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("AllowCors"), Route("order")]
    public class OrderController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await BL.BL.Instance.GetAllOrder());
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            return Ok(await BL.BL.Instance.AddOrder(order));
        }

        [HttpPost]
        [Route("addKrapfen")]
        public async Task<IActionResult> AddKrapfenToOrder(KrapfenOrder krapfenOrder)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetKrapfenById(krapfenOrder.Krapfen) == null)
                return NotFound("Krapfen not Found");
            if (await BL.BL.Instance.GetOrderById(krapfenOrder.Order) == null)
                return NotFound("Order not Found");
            var order = await BL.BL.Instance.GetOrderById(krapfenOrder.Order);
            order.KrapfenOrder.Add(krapfenOrder);
            return Ok(await BL.BL.Instance.UpdateOrder(order));
        }
        
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            return Ok(await BL.BL.Instance.GetOrderById(id));
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditOrder(Order order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetOrderById(order.Id) == null) return NotFound("Order not Found");
            return Ok(await BL.BL.Instance.UpdateOrder(order));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteOrder(Order order)
        {
            if (await BL.BL.Instance.GetOrderById(order.Id) == null) return NotFound("Order not Found");
            BL.BL.Instance.DeleteOrder(order);
            return Ok("Order deleted");
        }
    }
}