using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddSmokingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diabetes",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Heart",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Pressure",
                table: "Patients",
                newName: "Smoke");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Smoke",
                table: "Patients",
                newName: "Pressure");

            migrationBuilder.AddColumn<bool>(
                name: "Diabetes",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Heart",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
