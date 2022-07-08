using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetiJob.DataAccess.Migrations
{
    public partial class changeIranStatesCareerJobname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IranStates",
                table: "AspNetUsers",
                newName: "IranStatesCareerJob");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IranStatesCareerJob",
                table: "AspNetUsers",
                newName: "IranStates");
        }
    }
}
