using StudentMgmtProject.Model;
using StudentMgmtProject.Repository;
using StudentMgmtProject.Services.StudentService.Model;

namespace StudentMgmtProject.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentVM> GetAllStudents()
        {
            var students = _studentRepository.List().ToList();
            return students.Select(s => new StudentVM
            {
                StudentId = s.StudentId,
                RollNo = s.RollNo,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Gender = s.Gender,
                DateOfBirth = s.DateOfBirth,
                Address = s.Address,
                FatherName = s.FatherName,
                MotherName = s.MotherName,
                ProgramId = s.ProgramId,
                ProgramName = s.Program?.ProgramName
            }).ToList();
        }

        public StudentVM GetStudentById(int id)
        {
            var student = _studentRepository.Find(id);
            if (student == null) return null;

            return new StudentVM
            {
                StudentId = student.StudentId,
                RollNo = student.RollNo,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                FatherName = student.FatherName,
                MotherName = student.MotherName,
                ProgramId = student.ProgramId,
                ProgramName = student.Program?.ProgramName
            };
        }

        public void AddStudent(StudentVM model)
        {
            var student = new Student
            {
                RollNo = model.RollNo,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                FatherName = model.FatherName,
                MotherName = model.MotherName,
                ProgramId = model.ProgramId
            };

            _studentRepository.Add(student);
        }

        public void UpdateStudent(int id, StudentVM model)
        {
            var student = _studentRepository.Find(id);
            if (student == null) return;

            student.RollNo = model.RollNo;
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Email = model.Email;
            student.PhoneNumber = model.PhoneNumber;
            student.Gender = model.Gender;
            student.DateOfBirth = model.DateOfBirth;
            student.Address = model.Address;
            student.FatherName = model.FatherName;
            student.MotherName = model.MotherName;
            student.ProgramId = model.ProgramId;

            _studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
        }
    }
}
