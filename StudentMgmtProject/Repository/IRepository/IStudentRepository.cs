using StudentMgmtProject.Model;
namespace StudentMgmtProject.Repository.IRepository
{
    public interface IStudentRepository: IRepository<Student>
    {
        Student Get(int id);
        IEnumerable<Student> GetAll();
        void Update(Student student);
    }
}
