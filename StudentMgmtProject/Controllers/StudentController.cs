using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtProject.Services.StudentService.Model;
using StudentMgmtProject.Services.StudentService;

namespace StudentMgmtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdStudent = _studentService.AddStudent(model); 
            if (createdStudent == null) return BadRequest("Failed to create student.");

            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _studentService.UpdateStudent(id, model);
            return Ok("Student updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok("Student deleted successfully.");
        }
    }
}