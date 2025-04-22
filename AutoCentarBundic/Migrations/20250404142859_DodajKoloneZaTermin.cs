using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoCentarBundic.Migrations
{
    /// <inheritdoc />
    public partial class DodajKoloneZaTermin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Termini",
                newName: "Prezime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Termini",
                newName: "Datum");

            migrationBuilder.RenameColumn(
                name: "Car",
                table: "Termini",
                newName: "Ime");

            migrationBuilder.AddColumn<string>(
                name: "Automobil",
                table: "Termini",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Automobil",
                table: "Termini");

            migrationBuilder.RenameColumn(
                name: "Prezime",
                table: "Termini",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Ime",
                table: "Termini",
                newName: "Car");

            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "Termini",
                newName: "Date");
        }
    }
}
