using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jop_Portal.Data.Migrations
{
    /// <inheritdoc />
    public partial class editoffersmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Offers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
