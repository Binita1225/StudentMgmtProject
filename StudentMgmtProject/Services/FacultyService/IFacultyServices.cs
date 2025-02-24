using StudentMgmtProject.Model;

namespace StudentMgmtProject.Services.FacultyService
{
    public interface IFacultyServices  
    {
        IEnumerable<Faculty> GetAllFaculties();  
        Faculty GetFacultyById(int id);
        Faculty AddFaculty(Faculty faculty);
        Faculty UpdateFaculty(Faculty faculty);
        bool DeleteFaculty(int id);
    }
}
