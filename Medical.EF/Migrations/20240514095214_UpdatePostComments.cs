using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientPhone",
                table: "Comments",
                type: "nvarchar(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PatientPhone",
                table: "Comments",
                column: "PatientPhone");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Patients_PatientPhone",
                table: "Comments",
                column: "PatientPhone",
                principalTable: "Patients",
                principalColumn: "Phone",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Patients_PatientPhone",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PatientPhone",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PatientPhone",
                table: "Comments");
        }
    }
}
