using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSS.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationCareerModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImages", x => x.Id);
                });

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
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Individual = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Takula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Addresses_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.id);
                    table.ForeignKey(
                        name: "FK_Emails_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Members_MemberEmployeeId",
                        column: x => x.MemberEmployeeId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_Members_MemberOrganizationId",
                        column: x => x.MemberOrganizationId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneAreaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneLocalStdIsd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Phones_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmployer",
                columns: table => new
                {
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastEmployersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmployer", x => new { x.EmployeesId, x.PastEmployersId });
                    table.ForeignKey(
                        name: "FK_EmployeeEmployer_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEmployer_Employers_PastEmployersId",
                        column: x => x.PastEmployersId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberCandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearsOfExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CurrentEmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Employers_CurrentEmployerId",
                        column: x => x.CurrentEmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Candidates_Members_MemberCandidateId",
                        column: x => x.MemberCandidateId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobPostingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFiles_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageFiles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageFiles_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobPostingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobPostingId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSkills_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSkills_JobPostings_JobPostingId1",
                        column: x => x.JobPostingId1,
                        principalTable: "JobPostings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSkills_JobSkills_JobSkillId",
                        column: x => x.JobSkillId,
                        principalTable: "JobSkills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LinkHandles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkHandleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkHandleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkHandleUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkHandleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobPostingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkHandles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkHandles_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkHandles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkHandles_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkHandles_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MemberId",
                table: "Addresses",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CurrentEmployerId",
                table: "Candidates",
                column: "CurrentEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_MemberCandidateId",
                table: "Candidates",
                column: "MemberCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ProfileImagesId",
                table: "Candidates",
                column: "ProfileImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CandidateId",
                table: "Documents",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EmployeeId",
                table: "Documents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EmployerId",
                table: "Documents",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_JobPostingId",
                table: "Documents",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_MemberId",
                table: "Emails",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmployer_PastEmployersId",
                table: "EmployeeEmployer",
                column: "PastEmployersId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MemberEmployeeId",
                table: "Employees",
                column: "MemberEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_MemberOrganizationId",
                table: "Employers",
                column: "MemberOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFiles_CandidateId",
                table: "ImageFiles",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFiles_EmployeeId",
                table: "ImageFiles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFiles_EmployerId",
                table: "ImageFiles",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategoryJobPosting_JobPostingsId",
                table: "JobCategoryJobPosting",
                column: "JobPostingsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_CandidateId",
                table: "JobSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_EmployeeId",
                table: "JobSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobPostingId",
                table: "JobSkills",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobPostingId1",
                table: "JobSkills",
                column: "JobPostingId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobSkillId",
                table: "JobSkills",
                column: "JobSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkHandles_CandidateId",
                table: "LinkHandles",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkHandles_EmployeeId",
                table: "LinkHandles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkHandles_EmployerId",
                table: "LinkHandles",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkHandles_JobPostingId",
                table: "LinkHandles",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_MemberId",
                table: "Phones",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_ImageFiles_ProfileImagesId",
                table: "Candidates",
                column: "ProfileImagesId",
                principalTable: "ImageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Members_MemberCandidateId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Members_MemberEmployeeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Members_MemberOrganizationId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Employers_CurrentEmployerId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageFiles_Employers_EmployerId",
                table: "ImageFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_ImageFiles_ProfileImagesId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BlogImages");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "EmployeeEmployer");

            migrationBuilder.DropTable(
                name: "JobCategoryJobPosting");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "LinkHandles");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "JobPostings");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "ImageFiles");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
