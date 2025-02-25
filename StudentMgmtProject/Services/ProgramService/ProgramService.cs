using Microsoft.EntityFrameworkCore;
using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository;
using StudentMgmtProject.Services.ProgramService.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentMgmtProject.Services.ProgramService
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<Programms> _programRepository;
        private readonly IRepository<Faculty> _facultyRepository;

        public ProgramService(IRepository<Programms> programRepository, IRepository<Faculty> facultyRepository)
        {
            _programRepository = programRepository;
            _facultyRepository = facultyRepository;
        }

        public List<ProgramVM> GetAllPrograms()
        {
            return _programRepository.List().Select(p => new ProgramVM
            {
                ProgramId = p.ProgramId,
                ProgramName = p.ProgramName,
                FacultyId = p.FacultyId,
                DurationInYears = p.DurationInYears,
                Description = p.Description,
                IsActive = p.IsActive
            }).ToList();
        }

        public ProgramDetailViewModel GetProgramById(int id)
        {
            var program = _programRepository.Find(id);
            if (program == null) return null;

            var faculty = _facultyRepository.Find(program.FacultyId);

            return new ProgramDetailViewModel
            {
                ProgramId = program.ProgramId,
                ProgramName = program.ProgramName,
                FacultyId = program.FacultyId,
                FacultyName = faculty?.FacultyName,
                DurationInYears = program.DurationInYears,
                Description = program.Description,
                CreatedAt = program.CreatedAt,
                UpdatedAt = program.UpdatedAt,
                IsActive = program.IsActive
            };
        }

        public ProgramVM AddProgram(ProgramVM model)
        {
            var program = new Programms
            {
                ProgramName = model.ProgramName,
                FacultyId = model.FacultyId,
                DurationInYears = model.DurationInYears,
                Description = model.Description,
                IsActive = model.IsActive
            };

            _programRepository.Add(program);

            return new ProgramVM
            {
                ProgramId = program.ProgramId,
                ProgramName = program.ProgramName,
                FacultyId = program.FacultyId,
                DurationInYears = program.DurationInYears,
                Description = program.Description,
                IsActive = program.IsActive
            };
        }

        public ProgramVM UpdateProgram(ProgramVM model)
        {
            var program = _programRepository.Find(model.ProgramId);
            if (program == null) return null;

            program.ProgramName = model.ProgramName;
            program.FacultyId = model.FacultyId;
            program.DurationInYears = model.DurationInYears;
            program.Description = model.Description;
            program.IsActive = model.IsActive;
            program.UpdatedAt = DateTime.UtcNow;

            _programRepository.Update(program);

            return new ProgramVM
            {
                ProgramId = program.ProgramId,
                ProgramName = program.ProgramName,
                FacultyId = program.FacultyId,
                DurationInYears = program.DurationInYears,
                Description = program.Description,
                IsActive = program.IsActive
            };
        }

        public bool DeleteProgram(int id)
        {
            return _programRepository.Delete(id) > 0;
        }
    }
}