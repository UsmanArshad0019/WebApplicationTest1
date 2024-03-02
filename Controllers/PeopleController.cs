using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTest1.Models;
using WebApplicationTest1.Services;

namespace WebApplicationTest1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet("GetPeople")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IEnumerable<Person>> GetPeople()
        {
            var people = await _personService.GetPeople();
            return people;
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personService.GetPersonById(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }


        [HttpPost,Route("CreatePerson")]
        [Authorize(Roles = "Admin")]
        public async Task<Person> CreatePerson(Person person)
        {
            var newPerson = await _personService.CreatePerson(person);
            return newPerson;
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<Person> UpdatePerson(int id, Person person)
        {
            var updatedPerson = await _personService.UpdatePerson(id, person);
            if (updatedPerson == null)
                return null;
            return updatedPerson;
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<string> DeletePerson(int id)
        {
            var result = await _personService.DeletePerson(id);
            if (!result)
                return "Person Not Found";
            return "Person Deleted";
        }
    }
}
