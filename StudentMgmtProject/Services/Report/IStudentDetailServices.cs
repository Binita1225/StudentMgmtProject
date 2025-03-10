using StudentMgmtProject.Services.Report.ViewModels;

namespace StudentMgmtProject.Services.Report
{
    public interface IStudentDetailServices
    {
        List<StudentInfoVM> GetAllStudents();
    }
}
