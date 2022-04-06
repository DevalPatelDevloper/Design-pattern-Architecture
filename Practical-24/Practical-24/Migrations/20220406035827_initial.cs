using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Practical_24.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dept_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Employees_Tbl_Departments_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "Tbl_Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Employees_Dept_Id",
                table: "Tbl_Employees",
                column: "Dept_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Employees");

            migrationBuilder.DropTable(
                name: "Tbl_Departments");
        }
    }
}
