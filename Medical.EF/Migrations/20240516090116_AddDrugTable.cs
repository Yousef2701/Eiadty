using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddDrugTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Patient_Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Drug_Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => new { x.Drug_Name, x.Patient_Phone });
                    table.ForeignKey(
                        name: "FK_Drugs_Patients_Patient_Phone",
                        column: x => x.Patient_Phone,
                        principalTable: "Patients",
                        principalColumn: "Phone",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_Patient_Phone",
                table: "Drugs",
                column: "Patient_Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}
