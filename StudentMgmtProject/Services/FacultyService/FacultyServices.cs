using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentMgmtProject.Services.FacultyService
{
    public class FacultyServices : IFacultyServices
    {
        private readonly ApplicationDbContext _context;

        public FacultyServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _context.Faculties.ToList();
        }

        public Faculty GetFacultyById(int id)
        {
            return _context.Faculties.FirstOrDefault(f => f.FacultyId == id);
        }

        public Faculty AddFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
            return faculty;
        }

        public Faculty UpdateFaculty(Faculty faculty)
        {
            var existingFaculty = _context.Faculties.Find(faculty.FacultyId);
            if (existingFaculty == null)  {
                return null;
            }

            existingFaculty.FacultyName = faculty.FacultyName;
            _context.Faculties.Update(existingFaculty);
            _context.SaveChanges();
            return existingFaculty;

        }

        public bool DeleteFaculty(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty == null)
            {
                return false;
            }

            _context.Faculties.Remove(faculty);
            _context.SaveChanges();
            return true;
        }

    }
}
