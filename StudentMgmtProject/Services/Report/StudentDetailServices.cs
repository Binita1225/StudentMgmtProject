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

        //public List<StudentInfoVM> GetAllStudents()
        //{
        //    return _context.Students
        //        .FromSqlRaw("EXEC SelectAllStudents")
        //        .Select(s => new StudentInfoVM
        //        {
        //            StudentId = s.StudentId,
        //            RollNo = s.RollNo,
        //            FirstName = s.FirstName,
        //            LastName = s.LastName,
        //            Email = s.Email,
        //            PhoneNumber = s.PhoneNumber,
        //            Gender = s.Gender.ToString(), 
        //            DateOfBirth = s.DateOfBirth,
        //            Address = s.Address,
        //            FatherName = s.FatherName,
        //            MotherName = s.MotherName,
        //            ProgramName = s.Program.ProgramName 
        //        })
        //        .ToList();
        //}
    }
}
