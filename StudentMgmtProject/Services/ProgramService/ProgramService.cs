using Microsoft.EntityFrameworkCore;
using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository;
using StudentMgmtProject.Services.ProgramService.Model;

namespace StudentMgmtProject.Services.ProgramService
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<Programms> _context;
        public ProgramService(IRepository<Programms> programmsRepository)
        {
            _context = programmsRepository;
        }

        public Programms AddProgram(Programms programms)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProgram(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Programms> GetAllPrograms()
        {
            throw new NotImplementedException();
        }

        public Programms GetProgramById(int id)
        {
            throw new NotImplementedException();
        }

        public Programms UpdateProgram(Programms programms)
        {
            throw new NotImplementedException();
        }
    }
}
