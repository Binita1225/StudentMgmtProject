using StudentMgmtProject.Model;

namespace StudentMgmtProject.Services.ProgramService
{
    public interface IProgramService
    {
        IEnumerable<Programms> GetAllPrograms();
        Programms GetProgramById(int id);
        Programms AddProgram(Programms programms);
        Programms UpdateProgram(Programms programms);
        bool DeleteProgram(int id);
    }
}
