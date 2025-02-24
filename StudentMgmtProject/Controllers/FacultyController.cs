using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtProject.Model;
using StudentMgmtProject.Services.FacultyService;

namespace StudentMgmtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyServices _facultyServices;

        public FacultyController(IFacultyServices facultyServices)
        {
            _facultyServices = facultyServices;
        }

        [HttpGet]
        public IActionResult GetAllFaculties() 
        {
            var faculties = _facultyServices.GetAllFaculties();
            return Ok(faculties);
        }

        [HttpGet("{id}")]
        public IActionResult GetFacultyById(int id)
        {
            var faculty = _facultyServices.GetFacultyById(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return Ok(faculty);
        }

        [HttpPost]
        public IActionResult AddFaculty([FromBody] Faculty faculty)
        {
            var newFaculty = _facultyServices.AddFaculty(faculty);
            return CreatedAtAction(nameof(GetFacultyById), new { id = newFaculty.FacultyId }, newFaculty);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFaculty(int id, [FromBody] Faculty faculty)
        {
            if (id != faculty.FacultyId)
            {
                return BadRequest();
            }

           var updatedFaculty = _facultyServices.UpdateFaculty(faculty);
            if (updatedFaculty == null)
            {
                return NotFound();
            }
            return Ok(updatedFaculty);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFaculty(int id)
        {
            var success = _facultyServices.DeleteFaculty(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
