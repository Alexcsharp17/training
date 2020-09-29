using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarStore.DAL;
using CarStore.DAL.Entities;
using CarStore.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderService orderService;

        private IPersonService personService;
        public OrderController(IOrderService orderService, IPersonService personService)
        {
            this.orderService = orderService;
            this.personService = personService;
        }
        [HttpGet("[action]")]
        public ActionResult GetOrder([FromQuery]int id)
        {
            Order order = orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Content(JsonSerializer.Serialize(order));
        }

        [HttpGet("[action]")]
        public IActionResult GetOrders()
        {
            List<Order> orders = orderService.GetOrders();
            if (orders == null)
            {
                return NotFound();
            }
            return Content(JsonSerializer.Serialize(orders));
        }

        [HttpPost("[action]")]
        public IActionResult AddOrder([FromBody] Order order)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            orderService.AddOrder(order);
            return Ok();
        }
    }
}
