using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagement.Common.Entities;
using PersonManagement.Common.Interfaces.Service;

namespace PersonManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _personService.GetAllPeopleAsync();
            return Ok(persons);
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            try
            {
                await _personService.UpdatePersonAsync(person);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Persons
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            await _personService.AddPersonAsync(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await _personService.DeletePersonAsync(id);

            return NoContent();
        }

        private async Task<bool> PersonExists(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            return person != null;
        }
    }
}
