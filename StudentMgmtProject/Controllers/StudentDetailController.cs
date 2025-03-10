using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtProject.Services.Report;
using StudentMgmtProject.Services.Report.ViewModels;

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

        [HttpGet("semWise-students")]
        public IActionResult GetSemesterWiseReport()
        {
            var students = _studentDetailServices.GetSemesterWiseReport();
            return Ok(students);
        }

        [HttpGet("yearWise-students")]
        public IActionResult GetYearWiseReport()
        {
            var students = _studentDetailServices.GetYearWiseReport();
            return Ok(students);
        }

        [HttpGet("enroll-students/{programId}")]


        public ActionResult<List<StudentEnrollVM>> GetStudentsEnrolledInProgram(int programId)
        {
            var students = _studentDetailServices.GetStudentsEnrolledInProgram(programId);
            if (students == null || students.Count == 0)
            {
                return NotFound("No students found for the given program.");
            }
            return Ok(students);
        }


        //public ActionResult<List<StudentEnrollVM>> GetStudentsEnrolledInProgram(int programId) 
        //{
        //    var students = _studentDetailServices.GetStudentsEnrolledInProgram(programId);
        //    return Ok(students);

        //}

        //public IActionResult GetStudentsEnrolledInProgram()
        //{
        //    var students = _studentDetailServices.GetStudentsEnrolledInProgram();
        //    return Ok(students);
        //}
    }
}
