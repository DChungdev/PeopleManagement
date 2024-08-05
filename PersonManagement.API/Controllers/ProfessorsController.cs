using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagement.Common.Entities;
using PersonManagement.Common.Interfaces.Service;

namespace PersonManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorsController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
        {
            var professors = await _professorService.GetAllProfessorsAsync();
            return Ok(professors);
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _professorService.GetProfessorByIdAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, Professor professor)
        {
            if (id != professor.Id)
            {
                return BadRequest();
            }

            try
            {
                await _professorService.UpdateProfessorAsync(professor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProfessorExists(id))
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

     
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
            await _professorService.AddProfessorAsync(professor);
            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var professor = await _professorService.GetProfessorByIdAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            await _professorService.DeleteProfessorAsync(id);

            return NoContent();
        }

        private async Task<bool> ProfessorExists(int id)
        {
            var professor = await _professorService.GetProfessorByIdAsync(id);
            return professor != null;
        }
    }
}
