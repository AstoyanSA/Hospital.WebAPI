using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.WebAPI.Migrations
{
    public partial class RenameCabinetNumbertoCabinetCabNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Cabinets",
                newName: "CabNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CabNumber",
                table: "Cabinets",
                newName: "Number");
        }
    }
}
