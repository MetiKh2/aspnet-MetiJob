using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetiJob.DataAccess.Migrations
{
    public partial class addjobandcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<int>(type: "int", nullable: true),
                    FirstBannerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstBannerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondBannerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondBannerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdBannerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdBannerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthBannerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthBannerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthBannerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthBannerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Introduced = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkCulture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobBenefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker1_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker1_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker1_Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker1_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker2_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker2_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker2_Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker2_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker3_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker3_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker3_Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worker3_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    JobCategories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumWorkExperience = table.Column<int>(type: "int", nullable: true),
                    ContractsCategories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<long>(type: "bigint", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeedSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMan = table.Column<bool>(type: "bit", nullable: true),
                    MilitaryStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Educational = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHot = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
