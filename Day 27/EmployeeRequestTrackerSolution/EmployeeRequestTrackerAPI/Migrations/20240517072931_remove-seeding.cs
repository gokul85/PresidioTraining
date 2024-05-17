using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class removeseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Image", "Name", "Phone", "Role" },
                values: new object[] { 101, new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ramu", "9876543321", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Image", "Name", "Phone", "Role" },
                values: new object[] { 102, new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Somu", "9988776655", null });
        }
    }
}
