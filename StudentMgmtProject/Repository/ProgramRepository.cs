using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository.IRepository;

namespace StudentMgmtProject.Repository
{
    public class ProgramRepository : Repository<Programms>, IProgramRepository
    {

        private ApplicationDbContext _db;
        public ProgramRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Programms> GetAll()
        {
            return _db.Programs;
        }

        public void Update(Programms programms)
        {
            _db.Programs.Update(programms);
        }

    }
}
