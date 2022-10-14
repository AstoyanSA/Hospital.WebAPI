using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinetId = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Cabinets_CabinetId",
                        column: x => x.CabinetId,
                        principalTable: "Cabinets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 13 },
                    { 2, 4 },
                    { 3, 46 },
                    { 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "Cabinets",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 7 },
                    { 3, 12 },
                    { 4, 6 },
                    { 5, 8 },
                    { 6, 10 }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Педиатрия" },
                    { 2, "Хирургия" },
                    { 3, "Флебология" },
                    { 4, "Колопроктология" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AreaId", "CabinetId", "FullName", "SpecializationId" },
                values: new object[,]
                {
                    { 1, null, 2, "Попов Даниил Викторович", 3 },
                    { 2, null, 3, "Соколов Виктор Петрович", 2 },
                    { 3, 2, 1, "Михайлов Игорь Львович", 1 },
                    { 4, null, 6, "Федоров Богдан Антонович", 4 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "AreaId", "Birthday", "FirstName", "MiddleName", "Sex", "Surname" },
                values: new object[,]
                {
                    { 1, "улица Степная, дом 130", 4, new DateTime(1980, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Денис", "Евгеньевич", "М", "Петров" },
                    { 2, "улица Калинина, дом 6", 2, new DateTime(1994, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Олег", "Сергеевич", "М", "Иванов" },
                    { 3, "улица Гоголя, дом 12, квартира 8", 2, new DateTime(2000, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сергей", "Иванович", "М", "Смирнов" },
                    { 4, "улица Красная, дом 5", 3, new DateTime(1988, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Анастасия", "Николаевна", "м", "Жукова" },
                    { 5, "улица Мира, дом 64", 1, new DateTime(2007, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алексей", "Сергеевич", "ж", "Ульянов" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AreaId",
                table: "Doctors",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AreaId",
                table: "Patients",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
