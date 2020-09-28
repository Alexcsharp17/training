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

        [HttpGet("[action]")]
        public IActionResult GetPerson([FromQuery]int id)
        {
            Person person = PersonService.GetPerson(id);
            if (person==null)
            {
                return NotFound();
            }
            return Content(JsonSerializer.Serialize(person));
        }

        [HttpGet("[action]")]
        public IActionResult GetPersons()
        {
            List<Person> people = PersonService.GetPersons();
            if (people==null)
            {
                return NotFound();
            }
            return Content(JsonSerializer.Serialize(people));
        }

        [HttpPost("[action]")]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PersonService.AddPerson(person);
            return Ok();
        }

    }
}
