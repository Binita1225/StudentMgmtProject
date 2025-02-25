using System.Collections.Generic;
using StudentMgmtProject.Services.ProgramService.Model;

namespace StudentMgmtProject.Services.ProgramService
{
    public interface IProgramService
    {
        List<ProgramVM> GetAllPrograms();
        ProgramDetailViewModel GetProgramById(int id);
        ProgramVM AddProgram(ProgramVM program);  
        ProgramVM UpdateProgram(ProgramVM program);  
        bool DeleteProgram(int id);
    }
}
