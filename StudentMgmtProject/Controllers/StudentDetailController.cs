using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtProject.Services.Report;

namespace StudentMgmtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailController : ControllerBase
    {
        private readonly IStudentDetailServices _studentDetailServices;

        public StudentDetailController(IStudentDetailServices studentDetailServices)
        {
            _studentDetailServices = studentDetailServices;
        }

        [HttpGet("all-students")]
        public IActionResult GetAllStudents()
        {
            var students = _studentDetailServices.GetAllStudents();
            return Ok(students);
        }
    }
}
