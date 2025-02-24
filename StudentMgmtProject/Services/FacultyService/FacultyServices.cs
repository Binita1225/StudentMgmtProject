using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace StudentMgmtProject.Services.FacultyService
{
    public class FacultyServices : IFacultyServices
    {
        private readonly IRepository<Faculty> _faculty;

        public FacultyServices(IRepository<Faculty> faculty)
        {
            _faculty = faculty;
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _faculty.List();
        }

        public Faculty GetFacultyById(int id)
        {
            return _faculty.Find(id);
        }

        public Faculty AddFaculty(Faculty faculty)
        {
            _faculty.Add(faculty);
          
            return faculty;
        }

        public Faculty UpdateFaculty(Faculty faculty)
        {
            var existingFaculty = _faculty.Find(faculty.FacultyId);
            if (existingFaculty == null)  {
                return null;
            }

            existingFaculty.FacultyName = faculty.FacultyName;
            _faculty.Update(existingFaculty);
           
            return existingFaculty;

        }

        public bool DeleteFaculty(int id)
        {
            var faculty = _faculty.Find(id);
            if (faculty == null)
            {
                return false;
            }

            _faculty.Remove(faculty);
            
            return true;
        }

    }
}
