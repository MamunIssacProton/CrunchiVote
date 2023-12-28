using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrunchiVote.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updated_CrunchiVoteUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_AspNetUsers_UserId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_AspNetUsers_UserId",
                table: "Tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AspNetUsers_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "CrunchiVoteUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrunchiVoteUsers",
                table: "CrunchiVoteUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_CrunchiVoteUsers_UserId",
                table: "Claims",
                column: "UserId",
                principalTable: "CrunchiVoteUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_CrunchiVoteUsers_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "CrunchiVoteUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_CrunchiVoteUsers_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "CrunchiVoteUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_CrunchiVoteUsers_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "CrunchiVoteUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_CrunchiVoteUsers_UserId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_CrunchiVoteUsers_UserId",
                table: "Tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_CrunchiVoteUsers_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_CrunchiVoteUsers_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrunchiVoteUsers",
                table: "CrunchiVoteUsers");

            migrationBuilder.RenameTable(
                name: "CrunchiVoteUsers",
                newName: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_AspNetUsers_UserId",
                table: "Claims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_AspNetUsers_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AspNetUsers_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
