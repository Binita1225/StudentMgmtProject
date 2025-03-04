using StudentMgmtProject.Model;
using StudentMgmtProject.Services.FacultyService.DTOs;

namespace StudentMgmtProject.Services.FacultyService
{
    public interface IFacultyServices  
    {
        IEnumerable<FacultyDto> GetAllFaculties();
        FacultyDto GetFacultyById(int id);
        FacultyDto AddFaculty(FacultyDto facultyDto);
        FacultyDto UpdateFaculty(int id, FacultyDto facultyDto);
        bool DeleteFaculty(int id);
    }
}
