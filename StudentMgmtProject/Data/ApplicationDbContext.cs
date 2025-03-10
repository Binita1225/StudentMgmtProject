using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentMgmtProject.Model;
using StudentMgmtProject.Services.Report.ViewModels;

namespace StudentMgmtProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Programms> Programs { get; set; }

        public virtual List<StudentInfoVM> SelectAllStudents()
        {
            var data = this.Database.SqlQueryRaw<StudentInfoVM>("EXEC SelectAllStudents").ToList();
            return data;
        }

        public virtual List<SemWiseReportVM> GetSemesterWiseReport()
        {
            var data = this.Database.SqlQueryRaw<SemWiseReportVM>("EXEC GetSemesterWiseReport").ToList();

            foreach (var item in data)
            {
                Console.WriteLine($"Gender: {item.Gender}, CurrentSemester: {item.CurrentSemester}");
            }

            return data;
        }

        public virtual List<YearWiseReportVM> GetYearlyWiseReport()
        {
            var data = this.Database.SqlQueryRaw<YearWiseReportVM>("EXEC GetYearlyWiseReport").ToList();
            return data;
        }

        public virtual List<StudentEnrollVM> GetStudentsEnrolledInProgram(int programId)
        {
            var data = this.Database.SqlQueryRaw<StudentEnrollVM>(
        "EXEC GetStudentsEnrolledInProgram @ProgramId",
        new SqlParameter("@ProgramId", programId)
    ).ToList();
            //var data = this.Database.SqlQueryRaw<StudentEnrollVM>("EXEC GetStudentsEnrolledInProgram @ProgramId", new SqlParameter("@ProgramId", programId).ToList();
            return data;
        }

    }

}
