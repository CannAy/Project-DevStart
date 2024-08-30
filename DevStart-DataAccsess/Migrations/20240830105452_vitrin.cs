using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevStart_DataAccsess.Migrations
{
    /// <inheritdoc />
    public partial class vitrin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowCase",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowCase",
                table: "Courses");
        }
    }
}
