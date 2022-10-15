using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.WebAPI.Migrations
{
    public partial class RenameSpecializationNametoSpecializationSpecName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Specializations",
                newName: "SpecName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecName",
                table: "Specializations",
                newName: "Name");
        }
    }
}
