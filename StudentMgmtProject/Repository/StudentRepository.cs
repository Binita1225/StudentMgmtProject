using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository.IRepository;

namespace StudentMgmtProject.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Student Get(int id)
        {
            return _db.Students.FirstOrDefault(s => s.StudentId == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Students;
        }

        public void Update(Student student)
        {
            _db.Students.Update(student);
        }

    }
}
