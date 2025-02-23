namespace StudentMgmtProject.Services.Faculty
{
    public interface IFacultyServices
    {
        IEnumerable<Faculty> GetFaculties();
        Faculty GetFaculty(int id);

    }
}
