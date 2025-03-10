using StudentMgmtProject.Model;

namespace StudentMgmtProject.Services.ProgramService.Model
{
    public class ProgramVM
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int FacultyId { get; set; }
        public int DurationInYears { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ProgramType ProgramType { get; set; }
    }

    public class ProgramDetailViewModel
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int DurationInYears { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public ProgramType ProgramType { get; set; }
    }
}
