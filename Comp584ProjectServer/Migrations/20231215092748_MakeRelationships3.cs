using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comp584ProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class MakeRelationships3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookTitleIdId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BookTitleIdId",
                table: "Reviews",
                newName: "BookTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookTitleIdId",
                table: "Reviews",
                newName: "IX_Reviews_BookTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookTitleId",
                table: "Reviews",
                column: "BookTitleId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookTitleId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BookTitleId",
                table: "Reviews",
                newName: "BookTitleIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookTitleId",
                table: "Reviews",
                newName: "IX_Reviews_BookTitleIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookTitleIdId",
                table: "Reviews",
                column: "BookTitleIdId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
