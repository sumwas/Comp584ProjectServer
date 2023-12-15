using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comp584ProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReviewsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "UrlHandle",
                table: "Reviews",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Reviewer",
                table: "Reviews",
                newName: "Author");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Reviews",
                newName: "UrlHandle");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Reviews",
                newName: "Reviewer");

            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
