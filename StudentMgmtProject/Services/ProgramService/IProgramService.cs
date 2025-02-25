using System.Collections.Generic;
using StudentMgmtProject.Services.ProgramService.Model;

namespace StudentMgmtProject.Services.ProgramService
{
    public interface IProgramService
    {
        List<ProgramVM> GetAllPrograms();
        ProgramDetailViewModel GetProgramById(int id);
        ProgramVM AddProgram(ProgramVM program);  // Change return type to match implementation
        ProgramVM UpdateProgram(ProgramVM program);  // Change return type to match implementation
        bool DeleteProgram(int id);
    }
}
