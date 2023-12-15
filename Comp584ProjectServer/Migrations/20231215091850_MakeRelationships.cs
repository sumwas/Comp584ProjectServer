using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comp584ProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class MakeRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookTitleId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookTitleId",
                table: "Reviews",
                column: "BookTitleId");

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

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookTitleId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BookTitleId",
                table: "Reviews");
        }
    }
}
