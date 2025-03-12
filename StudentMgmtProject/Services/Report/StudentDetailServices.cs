using Microsoft.EntityFrameworkCore;
using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository;
using StudentMgmtProject.Services.Report.ViewModels;

namespace StudentMgmtProject.Services.Report
{
    public class StudentDetailServices : IStudentDetailServices
    {
        private readonly ApplicationDbContext _context;

        public StudentDetailServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<StudentInfoVM> GetAllStudents()
        {

            return _context.SelectAllStudents();
        }

        public List<SemWiseReportVM> GetSemesterWiseReport()
        {

            return _context.GetSemesterWiseReport();
        }


        public List<YearWiseReportVM> GetYearWiseReport()
        {

            return _context.GetYearlyWiseReport();
        }

        public List<StudentEnrollVM> GetStudentsEnrolledInProgram(int programId)
        {

            return _context.GetStudentsEnrolledInProgram(programId);
        }



        public async Task<List<ProgramVM>> GetStudentsProgram()
        {
            return await _context.Programs
                .Select(p => new ProgramVM
                {
                    ProgramId = p.ProgramId,
                    ProgramName = p.ProgramName
                })
                .ToListAsync();
        }
    }
}
