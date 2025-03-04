using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository;
using StudentMgmtProject.Services.FacultyService.DTOs;
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

        public IEnumerable<FacultyDto> GetAllFaculties()
        {
            return _faculty.List().Select(f => new FacultyDto
            {
                FacultyId = f.FacultyId,
                FacultyName = f.FacultyName
            }).ToList();
        }

        public FacultyDto GetFacultyById(int id)
        {
            var faculty = _faculty.Find(id);
            if (faculty == null) return null;

            return new FacultyDto
            {
                FacultyId = faculty.FacultyId,
                FacultyName = faculty.FacultyName
            };
        }

        public FacultyDto AddFaculty(FacultyDto facultyDto)
        {
            var faculty = new Faculty
            {
                FacultyName = facultyDto.FacultyName
            };

            var newFaculty = _faculty.Add(faculty);

            return new FacultyDto
            {
                FacultyId = newFaculty.FacultyId,
                FacultyName = newFaculty.FacultyName
            };
        }

        public FacultyDto UpdateFaculty(int id, FacultyDto facultyDto)
        {
            var existingFaculty = _faculty.Find(id);
            if (existingFaculty == null) return null;

            existingFaculty.FacultyName = facultyDto.FacultyName;
            _faculty.Update(existingFaculty);

            return new FacultyDto
            {
                FacultyId = existingFaculty.FacultyId,
                FacultyName = existingFaculty.FacultyName
            };
        }

        public bool DeleteFaculty(int id)
        {
            var faculty = _faculty.Find(id);
            if (faculty == null) return false;

            _faculty.Remove(faculty);
            return true;
        }

    }
}
