using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrunchiVote.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class upVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Votes_CommentId_GivenBy",
                table: "Votes");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CommentId_GivenBy",
                table: "Votes",
                columns: new[] { "CommentId", "GivenBy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Votes_CommentId_GivenBy",
                table: "Votes");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CommentId_GivenBy",
                table: "Votes",
                columns: new[] { "CommentId", "GivenBy" },
                unique: true);
        }
    }
}
