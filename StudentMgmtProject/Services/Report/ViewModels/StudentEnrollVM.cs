namespace StudentMgmtProject.Services.Report.ViewModels
{
    public class StudentEnrollVM
    {
        public int StudentId { get; set; }
        public string RollNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public string ProgramName { get; set; }

        public int ProgramType { get; set; }
        public int DurationInYears { get; set; }
   
    }
}
