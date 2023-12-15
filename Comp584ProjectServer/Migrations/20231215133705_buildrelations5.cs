using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comp584ProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class buildrelations5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookTitleId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.RenameColumn(
                name: "BookTitleId",
                table: "Reviews",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookTitleId",
                table: "Reviews",
                newName: "IX_Reviews_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Reviews",
                newName: "BookTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                newName: "IX_Reviews_BookTitleId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookTitleId",
                table: "Reviews",
                column: "BookTitleId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
