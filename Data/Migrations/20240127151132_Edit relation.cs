using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jop_Portal.Data.Migrations
{
    /// <inheritdoc />
    public partial class Editrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AspNetUsers_UserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Offers_OffersId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Account_AccountId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Prerequisites_prerequisitesId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Prerequisites_Offers_prerequisites",
                table: "Prerequisites");

            migrationBuilder.DropIndex(
                name: "IX_Offers_AccountId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_prerequisitesId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Account_OffersId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_UserId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "prerequisitesId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OffersId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "prerequisites",
                table: "Prerequisites",
                newName: "Prerequisites");

            migrationBuilder.RenameIndex(
                name: "IX_Prerequisites_prerequisites",
                table: "Prerequisites",
                newName: "IX_Prerequisites_Prerequisites");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Prerequisites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prerequisites_OfferId",
                table: "Prerequisites",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AspNetUsers_Id",
                table: "Account",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prerequisites_Offers_OfferId",
                table: "Prerequisites",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prerequisites_Offers_Prerequisites",
                table: "Prerequisites",
                column: "Prerequisites",
                principalTable: "Offers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AspNetUsers_Id",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Prerequisites_Offers_OfferId",
                table: "Prerequisites");

            migrationBuilder.DropForeignKey(
                name: "FK_Prerequisites_Offers_Prerequisites",
                table: "Prerequisites");

            migrationBuilder.DropIndex(
                name: "IX_Prerequisites_OfferId",
                table: "Prerequisites");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Prerequisites");

            migrationBuilder.RenameColumn(
                name: "Prerequisites",
                table: "Prerequisites",
                newName: "prerequisites");

            migrationBuilder.RenameIndex(
                name: "IX_Prerequisites_Prerequisites",
                table: "Prerequisites",
                newName: "IX_Prerequisites_prerequisites");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "prerequisitesId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OffersId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Account",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AccountId",
                table: "Offers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_prerequisitesId",
                table: "Offers",
                column: "prerequisitesId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_OffersId",
                table: "Account",
                column: "OffersId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                table: "Account",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AspNetUsers_UserId",
                table: "Account",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Offers_OffersId",
                table: "Account",
                column: "OffersId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Account_AccountId",
                table: "Offers",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Prerequisites_prerequisitesId",
                table: "Offers",
                column: "prerequisitesId",
                principalTable: "Prerequisites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prerequisites_Offers_prerequisites",
                table: "Prerequisites",
                column: "prerequisites",
                principalTable: "Offers",
                principalColumn: "Id");
        }
    }
}
