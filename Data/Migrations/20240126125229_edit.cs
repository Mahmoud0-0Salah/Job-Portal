using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jop_Portal.Data.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AccountId",
                table: "Offers",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Account_AccountId",
                table: "Offers",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Account_AccountId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_AccountId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Offers");
        }
    }
}
