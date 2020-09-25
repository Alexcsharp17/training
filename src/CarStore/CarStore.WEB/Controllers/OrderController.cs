using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarStore.DAL;
using CarStore.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {   
        [HttpGet]
        public string GetOrder([FromQuery]int id)
        {
            return JsonSerializer.Serialize( StoredProceduresService.GetOrder(id));
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            StoredProceduresService.AddOrder(order);
            return Ok();
        }
        
    }
}
