using StudentMgmtProject.Services.Report.ViewModels;

namespace StudentMgmtProject.Services.Report
{
    public interface IStudentDetailServices
    {
        List<StudentInfoVM> GetAllStudents();
        List<SemWiseReportVM> GetSemesterWiseReport();
        List<YearWiseReportVM> GetYearWiseReport();
        List<StudentEnrollVM> GetStudentsEnrolledInProgram(int programId);
    }
}
