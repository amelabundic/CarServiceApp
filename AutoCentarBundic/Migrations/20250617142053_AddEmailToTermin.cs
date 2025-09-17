using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoCentarBundic.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToTermin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Termini",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Termini");
        }
    }
}
