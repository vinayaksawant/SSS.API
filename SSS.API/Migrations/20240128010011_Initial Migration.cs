using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSS.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPostings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeaturedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategoryJobPosting",
                columns: table => new
                {
                    JobCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategoryJobPosting", x => new { x.JobCategoriesId, x.JobPostingsId });
                    table.ForeignKey(
                        name: "FK_JobCategoryJobPosting_JobCategories_JobCategoriesId",
                        column: x => x.JobCategoriesId,
                        principalTable: "JobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCategoryJobPosting_JobPostings_JobPostingsId",
                        column: x => x.JobPostingsId,
                        principalTable: "JobPostings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCategoryJobPosting_JobPostingsId",
                table: "JobCategoryJobPosting",
                column: "JobPostingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCategoryJobPosting");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "JobPostings");
        }
    }
}
