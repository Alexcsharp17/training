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
        public IActionResult GetPersons([FromQuery]int page,[FromQuery]int pageSize=10, [FromQuery] string sort="@PersonID")
        {
            List<Person> people = new List<Person>();
            try
                {
                    people = PersonService.GetPersons(page,pageSize,sort);
                    Response.StatusCode = 200;
                    return Content(JsonSerializer.Serialize(people));
                }
                catch (Exception e)
                {
                    Response.StatusCode = 400;
                    return Content(JsonSerializer.Serialize(ModelState));
                }

        }

        [HttpPost("[action]")]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Content(JsonSerializer.Serialize(ModelState));
            }
            try
            {
                PersonService.AddPerson(person);
                return Ok(JsonSerializer.Serialize(ModelState));
            }
            catch
            {
                Response.StatusCode = 400;
                return Content(JsonSerializer.Serialize(ModelState));
            }
        }

        [HttpDelete("[action]")]
        public IActionResult DeletePerson([FromQuery] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    PersonService.DeletePerson(id);
                    return Ok(ModelState);
                }
                catch
                {
                    Response.StatusCode = 400;
                    ModelState.AddModelError("IdError","Canot delete person, who has active order records");
                    return Content(JsonSerializer.Serialize(ModelState));
                }
            }
        }

    }
}
