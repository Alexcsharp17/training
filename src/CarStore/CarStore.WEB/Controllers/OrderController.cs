using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using CarStore.DAL;
using CarStore.DAL.Entities;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public IActionResult GetOrders([FromQuery]int page=0,[FromQuery] int pageSize=10, [FromQuery] string sort =DBColumns.PERSON_ID)
        {
            List<Order> orders = new List<Order>();
            try
                {
                    orders = orderService.GetOrders(page,pageSize,sort);
                    Response.StatusCode = 200;
                    return Content(JsonSerializer.Serialize(orders));
                }
                catch (Exception e)
                {
                    Response.StatusCode = 400;
                    return Content(JsonSerializer.Serialize(ModelState));
                }

        }

        [HttpPost("[action]")]
        public IActionResult AddOrder([FromBody] Order order)
        {

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                ModelState.AddModelError("IdError","Message");
                return Content(JsonSerializer.Serialize(ModelState));
 
            }

            try
            {
                orderService.AddOrder(order);
                return Ok(JsonSerializer.Serialize((ModelState)));
            }
            catch (DbException e)
            {
                Response.StatusCode = 400;
                return Content(JsonSerializer.Serialize(ModelState));
            }
          
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteOrder([FromQuery] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    orderService.DeleteOrder(id);
                    return Ok();
                }
                catch
                {
                    Response.StatusCode = 400;
                    return Content(JsonSerializer.Serialize(ModelState));
                }
                
            }
        }

    }
}
