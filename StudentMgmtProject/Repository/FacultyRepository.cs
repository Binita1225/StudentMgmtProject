using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository.IRepository;

namespace StudentMgmtProject.Repository
{
    public class FacultyRepository :Repository<Faculty>, IFacultyRepository
    {
        private ApplicationDbContext _db;
        public FacultyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Faculty> GetAll()
        {
            return _db.Faculties;
        }

        public void Update(Faculty obj)
        {
            _db.Faculties.Update(obj);
        }

    }
}
