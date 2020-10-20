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
        public ActionResult GetOrder([FromQuery] int id)
        {
            try
            {
                Order order = orderService.GetOrder(id);
                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetOrders([FromQuery] int page = 0, [FromQuery] int pageSize = 5, [FromQuery] string sort = DBColumns.PERSON_ID)
        {
            List<Order> orders = new List<Order>();
            try
            {
                orders = orderService.GetOrders(page, pageSize, sort);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("[action]")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("IdError", "Message");
                return BadRequest(ModelState);
            }

            try
            {
                orderService.AddOrder(order);
                return Ok(ModelState);
            }
            catch (DbException e)
            {
                return BadRequest(ModelState);
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
                    return BadRequest(ModelState);
                }

            }
        }

        [HttpGet("[action]")]
        public IActionResult GetOrdersCount()
        {
            try
            {
                int res = orderService.GetOrdersCount();

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }

        }

    }
}
