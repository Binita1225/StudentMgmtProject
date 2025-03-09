using StudentMgmtProject.Model;
using StudentMgmtProject.Services.StudentService.Model;

namespace StudentMgmtProject.Services.StudentService
{
    public interface IStudentService
    {
        List<StudentVM> GetAllStudents();
        StudentVM GetStudentById(int id);
        StudentVM AddStudent(StudentVM model);
        void UpdateStudent(int id, StudentVM model);
        void DeleteStudent(int id);
    }
}
