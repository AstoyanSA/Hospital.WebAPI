using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.WebAPI.Migrations
{
    public partial class RenameAreaNumbertoAreaAreaNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Areas",
                newName: "AreaNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AreaNumber",
                table: "Areas",
                newName: "Number");
        }
    }
}
