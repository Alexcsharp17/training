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
        private IPersonService PersonService;
        public PersonController(IPersonService personService)
        {
            this.PersonService = personService;
        }

        [HttpGet]
        public string GetPerson([FromQuery]int id)
        {
            return JsonSerializer.Serialize(PersonService.GetPerson(id));
        }

        [HttpGet]
        public string GetPersons()
        {
            return JsonSerializer.Serialize(PersonService.GetPersons());
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            PersonService.AddPerson(person);
            return Ok();
        }

    }
}
