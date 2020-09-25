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
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IStoredProceduresService StoredProcedures;
        public PersonController(IStoredProceduresService storedProcedures)
        {
            this.StoredProcedures = storedProcedures;
        }

        [HttpGet]
        public string GetPerson([FromQuery]int id)
        {
            return JsonSerializer.Serialize(StoredProcedures.GetPerson(id));
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            StoredProcedures.AddOrder(order);
            return Ok();
        }

    }
}
