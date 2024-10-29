using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddRayAndAnalysisMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Check_Books_Book_Numbre",
                table: "Check");

            migrationBuilder.DropForeignKey(
                name: "FK_Check_Doctors_Doctor_Phone",
                table: "Check");

            migrationBuilder.DropForeignKey(
                name: "FK_Check_Patients_Patient_Phone",
                table: "Check");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Check",
                table: "Check");

            migrationBuilder.RenameTable(
                name: "Check",
                newName: "Checks");

            migrationBuilder.RenameIndex(
                name: "IX_Check_Patient_Phone",
                table: "Checks",
                newName: "IX_Checks_Patient_Phone");

            migrationBuilder.RenameIndex(
                name: "IX_Check_Doctor_Phone",
                table: "Checks",
                newName: "IX_Checks_Doctor_Phone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checks",
                table: "Checks",
                column: "Book_Numbre");

            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    Numbre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Numbre = table.Column<int>(type: "int", nullable: false),
                    Analysis_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => x.Numbre);
                    table.ForeignKey(
                        name: "FK_Analyses_Checks_Book_Numbre",
                        column: x => x.Book_Numbre,
                        principalTable: "Checks",
                        principalColumn: "Book_Numbre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rays",
                columns: table => new
                {
                    Numbre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Numbre = table.Column<int>(type: "int", nullable: false),
                    Ray_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rays", x => x.Numbre);
                    table.ForeignKey(
                        name: "FK_Rays_Checks_Book_Numbre",
                        column: x => x.Book_Numbre,
                        principalTable: "Checks",
                        principalColumn: "Book_Numbre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_Book_Numbre",
                table: "Analyses",
                column: "Book_Numbre");

            migrationBuilder.CreateIndex(
                name: "IX_Rays_Book_Numbre",
                table: "Rays",
                column: "Book_Numbre");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Books_Book_Numbre",
                table: "Checks",
                column: "Book_Numbre",
                principalTable: "Books",
                principalColumn: "Numbre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Doctors_Doctor_Phone",
                table: "Checks",
                column: "Doctor_Phone",
                principalTable: "Doctors",
                principalColumn: "Phone",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Patients_Patient_Phone",
                table: "Checks",
                column: "Patient_Phone",
                principalTable: "Patients",
                principalColumn: "Phone",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Books_Book_Numbre",
                table: "Checks");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Doctors_Doctor_Phone",
                table: "Checks");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Patients_Patient_Phone",
                table: "Checks");

            migrationBuilder.DropTable(
                name: "Analyses");

            migrationBuilder.DropTable(
                name: "Rays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checks",
                table: "Checks");

            migrationBuilder.RenameTable(
                name: "Checks",
                newName: "Check");

            migrationBuilder.RenameIndex(
                name: "IX_Checks_Patient_Phone",
                table: "Check",
                newName: "IX_Check_Patient_Phone");

            migrationBuilder.RenameIndex(
                name: "IX_Checks_Doctor_Phone",
                table: "Check",
                newName: "IX_Check_Doctor_Phone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Check",
                table: "Check",
                column: "Book_Numbre");

            migrationBuilder.AddForeignKey(
                name: "FK_Check_Books_Book_Numbre",
                table: "Check",
                column: "Book_Numbre",
                principalTable: "Books",
                principalColumn: "Numbre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Check_Doctors_Doctor_Phone",
                table: "Check",
                column: "Doctor_Phone",
                principalTable: "Doctors",
                principalColumn: "Phone",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Check_Patients_Patient_Phone",
                table: "Check",
                column: "Patient_Phone",
                principalTable: "Patients",
                principalColumn: "Phone",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
