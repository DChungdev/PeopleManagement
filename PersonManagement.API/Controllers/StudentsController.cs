using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagement.Common.Entities;
using PersonManagement.Common.Interfaces.Service;

namespace PersonManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

   
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                await _studentService.UpdateStudentAsync(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StudentExists(id))
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
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentService.DeleteStudentAsync(id);

            return NoContent();
        }

        private async Task<bool> StudentExists(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            return student != null;
        }
    }
}
