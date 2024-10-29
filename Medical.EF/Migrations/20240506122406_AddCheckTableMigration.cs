using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Check",
                columns: table => new
                {
                    Book_Numbre = table.Column<int>(type: "int", nullable: false),
                    Complaint = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Doctor_Phone = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Patient_Phone = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Time = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Am_Pm = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    DrugListUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RayListUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalysistListUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check", x => x.Book_Numbre);
                    table.ForeignKey(
                        name: "FK_Check_Books_Book_Numbre",
                        column: x => x.Book_Numbre,
                        principalTable: "Books",
                        principalColumn: "Numbre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Check_Doctors_Doctor_Phone",
                        column: x => x.Doctor_Phone,
                        principalTable: "Doctors",
                        principalColumn: "Phone",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Check_Patients_Patient_Phone",
                        column: x => x.Patient_Phone,
                        principalTable: "Patients",
                        principalColumn: "Phone",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Check_Doctor_Phone",
                table: "Check",
                column: "Doctor_Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Check_Patient_Phone",
                table: "Check",
                column: "Patient_Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Check");
        }
    }
}
