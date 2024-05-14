using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorPatient.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DocId);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DocId", "DocName", "Experience", "Specialization" },
                values: new object[] { 1, "Ram", 0f, "Cardiologist" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DocId", "DocName", "Experience", "Specialization" },
                values: new object[] { 2, "Raj", 0f, "Orthologist" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DocId", "DocName", "Experience", "Specialization" },
                values: new object[] { 3, "Rahul", 0f, "Neurologist" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
