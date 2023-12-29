using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrunchiVote.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GivenBy = table.Column<string>(type: "text", nullable: true),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoteType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CommentId_GivenBy",
                table: "Votes",
                columns: new[] { "CommentId", "GivenBy" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
