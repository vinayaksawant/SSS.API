using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSS.API.Migrations
{
    /// <inheritdoc />
    public partial class updatedjobskillasstringinJobskillDomainmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_JobSkills_JobSkillId",
                table: "JobSkills");

            migrationBuilder.DropIndex(
                name: "IX_JobSkills_JobSkillId",
                table: "JobSkills");

            migrationBuilder.DropColumn(
                name: "JobSkillId",
                table: "JobSkills");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "JobSkills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "JobSkills");

            migrationBuilder.AddColumn<Guid>(
                name: "JobSkillId",
                table: "JobSkills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobSkillId",
                table: "JobSkills",
                column: "JobSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_JobSkills_JobSkillId",
                table: "JobSkills",
                column: "JobSkillId",
                principalTable: "JobSkills",
                principalColumn: "Id");
        }
    }
}
