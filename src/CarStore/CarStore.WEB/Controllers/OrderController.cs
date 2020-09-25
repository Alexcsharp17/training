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
        private IOrderService StoredProcedures;
        public OrderController(IOrderService storedProcedures)
        {
            this.StoredProcedures = storedProcedures;
        }
        [HttpGet("[action]")]
        public string GetOrder([FromQuery]int id)
        {
            return JsonSerializer.Serialize( StoredProcedures.GetOrder(id));
        }

        [HttpPost("[action]")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            StoredProcedures.AddOrder(order);
            return Ok();
        }
        

    }
}
