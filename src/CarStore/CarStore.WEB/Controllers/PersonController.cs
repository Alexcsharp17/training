using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarStore.DAL;
using CarStore.DAL.Entities;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public IActionResult GetPersonsCount()
        {
            try
            {
                object res = PersonService.GetPersonsCount();
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("[action]")]
        public IActionResult GetPerson([FromQuery] int id)
        {
            Person person = PersonService.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return Content(JsonSerializer.Serialize(person));
        }

        [HttpGet("[action]")]
        public IActionResult GetPersons([FromQuery] int page = 1, [FromQuery] int pageSize = 5, [FromQuery] string sort = DBColumns.PERSON_ID)
        {
            List<Person> people = new List<Person>();
            try
            {
                page = page < 0 ? 1 : page;
                people = PersonService.GetPersons(page, pageSize, sort);
                return Ok(people);
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPost("[action]")]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PersonService.AddPerson(person);
                return Ok(ModelState);
            }
            catch
            {
                return BadRequest(ModelState);
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
                    ModelState.AddModelError("IdError", "Canot delete person, who has active order records");
                    return BadRequest(ModelState);
                }
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetAllPersons()
        {
            try
            {
                var persons = PersonService.GetAllPersons();
                return Ok(persons);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("[action]")]
        public IActionResult FindPersons([FromQuery] string pattern=" ")
        {
            try
            {
                pattern = pattern == null ? " " : pattern;
                var persons = PersonService.FindPersons(pattern);
                return Ok(persons);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
