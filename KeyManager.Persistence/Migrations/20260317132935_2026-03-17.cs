using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _20260317 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SSN",
                table: "Users",
                newName: "Pnum");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Pnum",
                table: "Users",
                newName: "SSN");
        }
    }
}
