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
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public string GetPerson([FromQuery]int id)
        {
            return JsonSerializer.Serialize(StoredProceduresService.GetPerson(id));
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            StoredProceduresService.AddOrder(order);
            return Ok();
        }

    }
}
