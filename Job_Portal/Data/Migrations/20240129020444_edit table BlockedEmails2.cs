using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jop_Portal.Data.Migrations
{
    /// <inheritdoc />
    public partial class edittableBlockedEmails2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedEmails_AspNetUsers_Email",
                table: "BlockedEmails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockedEmails",
                table: "BlockedEmails");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BlockedEmails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "BlockedEmails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockedEmails",
                table: "BlockedEmails",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedEmails_AspNetUsers_id",
                table: "BlockedEmails",
                column: "id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedEmails_AspNetUsers_id",
                table: "BlockedEmails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockedEmails",
                table: "BlockedEmails");

            migrationBuilder.DropColumn(
                name: "id",
                table: "BlockedEmails");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BlockedEmails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockedEmails",
                table: "BlockedEmails",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedEmails_AspNetUsers_Email",
                table: "BlockedEmails",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
