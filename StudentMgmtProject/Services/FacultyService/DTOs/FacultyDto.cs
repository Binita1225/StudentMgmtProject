using System.ComponentModel.DataAnnotations;

namespace StudentMgmtProject.Services.FacultyService.DTOs
{
    public class FacultyDto
    {
        public int FacultyId { get; set; }

        [Required, StringLength(100)]
        public string FacultyName { get; set; }
    }
}
