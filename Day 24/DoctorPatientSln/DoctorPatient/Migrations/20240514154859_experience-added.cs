using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorPatient.Migrations
{
    public partial class experienceadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 1,
                column: "Experience",
                value: 1.5f);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 2,
                column: "Experience",
                value: 2.5f);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 3,
                column: "Experience",
                value: 3.5f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 1,
                column: "Experience",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 2,
                column: "Experience",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 3,
                column: "Experience",
                value: 0f);
        }
    }
}
