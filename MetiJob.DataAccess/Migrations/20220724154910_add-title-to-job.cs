using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetiJob.DataAccess.Migrations
{
    public partial class addtitletojob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Jobs");
        }
    }
}
