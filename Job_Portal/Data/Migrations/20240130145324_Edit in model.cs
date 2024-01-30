using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jop_Portal.Data.Migrations
{
    /// <inheritdoc />
    public partial class Editinmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserPhoto",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UserPhoto",
                table: "Offers");
        }
    }
}
