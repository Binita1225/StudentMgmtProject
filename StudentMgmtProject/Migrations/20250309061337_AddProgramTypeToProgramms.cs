using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentMgmtProject.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramTypeToProgramms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramType",
                table: "Programs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgramType",
                table: "Programs");
        }
    }
}
