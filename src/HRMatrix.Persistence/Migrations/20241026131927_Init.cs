using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VideoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AspNetUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetencyTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompetencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetencyTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetencyTranslations_Competencies_CompetencyId",
                        column: x => x.CompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevelTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EducationLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevelTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationLevelTranslation_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatusTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatusTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaritalStatusTranslations_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecializationsTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationsTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecializationsTranslation_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    TimesMarried = table.Column<int>(type: "int", nullable: false),
                    MarriagePeriods = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyStatuses_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyStatuses_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssignedUserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_AssignedUserProfileId",
                        column: x => x.AssignedUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileCompetencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    CompetencyId = table.Column<int>(type: "int", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileCompetencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileCompetencies_Competencies_CompetencyId",
                        column: x => x.CompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileCompetencies_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    EducationLevelId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileEducations_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileEducations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileLanguages_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Achievements = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillTranslation_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileSkills_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "User", "USER" },
                    { 2, null, "SuperUser", "SUPERUSER" },
                    { 3, null, "HR", "HR" },
                    { 4, null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "c2c0ebe2-8653-4a1f-b9a6-e1670f414070", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@mail.com", false, "John", "Doe", false, null, "USER@MAIL.COM", "USER", "AQAAAAIAAYagAAAAEK3XiTE6x+2IXjB6F9EWL0LbULt1i5btE1nnYnA+pPe+ZC65KhWFnJKH4OZieIX8Cw==", null, false, "b17a677e-7a6e-4c59-888d-360cbe8ba8ae", false, "user" },
                    { 2, 0, "b71c94e2-8be4-4e87-99c7-0a6c7089b179", new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "superuser@mail.com", false, "Jane", "Doe", false, null, "SUPERUSER@MAIL.COM", "SUPERUSER", "AQAAAAIAAYagAAAAEOOEkuB0SHOmCqPBUPRMcwB2hn3r/A8f/w4uKS6QY6l6V9jzXDM0Bq5r+pvuA5p3Qw==", null, false, "66fc5a21-593d-47e7-9b6d-d103ba14bcb2", false, "superuser" },
                    { 3, 0, "7e4f66f2-e08b-438a-ad1b-145c6fe60570", new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hr@mail.com", false, "Alice", "Smith", false, null, "HR@MAIL.COM", "HR", "AQAAAAIAAYagAAAAEG8ovQAIcYS1EVbLXUnQ+icJzCzNzg93mVQ1YBFz+xrPDtNSvQHZ6hboHJXsTTp0uQ==", null, false, "e48102ee-3965-4637-93f4-9ea842f0756c", false, "hr" },
                    { 4, 0, "743f9c1a-f81a-452c-a8b7-9d4310187539", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@mail.com", false, "Bob", "Johnson", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEJ3gh38dCdSaQ6TTXG+Ov0uxmKH0LA43iDX0wWvNqXhzs8/C10r0aDQBOatlH92ceQ==", null, false, "c36f2590-6dce-4869-a5dd-fc5ce21cbd1e", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Competencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Эффективная коммуникация" },
                    { 2, "Клиентоориентированность" },
                    { 3, "Умение работать в команде" },
                    { 4, "Ориентация на результат" },
                    { 5, "Негативный настрой (пессимизм)" },
                    { 6, "Равнодушие" },
                    { 7, "Лицемерие" },
                    { 8, "Лидерство" },
                    { 9, "Надежность / Стабильность" },
                    { 10, "Развитие бизнеса / Партнерство" },
                    { 11, "Креативное мышление" },
                    { 12, "Стратегическое мышление" },
                    { 13, "Самоорганизация" }
                });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Высшее законченное (Магистр)" },
                    { 2, "Среднее специальное / профессиональное" },
                    { 3, "Кандидат наук" },
                    { 4, "Доктор наук" },
                    { 5, "Доцент" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Английский" },
                    { 2, "Турецкий" },
                    { 3, "Немецкий" },
                    { 4, "Китайский" },
                    { 5, "Испанский" },
                    { 6, "Французский" },
                    { 7, "Итальянский" },
                    { 8, "Португальский" },
                    { 9, "Русский" },
                    { 10, "Японский" },
                    { 11, "Корейский" },
                    { 12, "Арабский" },
                    { 13, "Голландский" },
                    { 14, "Греческий" },
                    { 15, "Хинди" },
                    { 16, "Шведский" },
                    { 17, "Норвежский" },
                    { 18, "Датский" },
                    { 19, "Финский" },
                    { 20, "Польский" },
                    { 21, "Чешский" },
                    { 22, "Словацкий" },
                    { 23, "Украинский" },
                    { 24, "Белорусский" },
                    { 25, "Венгерский" },
                    { 26, "Румынский" },
                    { 27, "Болгарский" },
                    { 28, "Сербский" },
                    { 29, "Хорватский" },
                    { 30, "Словенский" },
                    { 31, "Литовский" },
                    { 32, "Латышский" },
                    { 33, "Эстонский" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Женат/Замужем" },
                    { 2, "Холост/Не замужем" },
                    { 3, "Разведен(а)" }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Разработка FrontEnd" },
                    { 2, "Разработка BackEnd" },
                    { 3, "Наука о данных и аналитика" },
                    { 4, "Машинное обучение и ИИ" },
                    { 5, "DevOps и облачные технологии" },
                    { 6, "Мобильная разработка" },
                    { 7, "Кибербезопасность" },
                    { 8, "Управление проектами и продуктами" },
                    { 9, "Сетевые технологии и поддержка ИТ" },
                    { 10, "Управление базами данных" },
                    { 11, "Дизайн UI/UX" },
                    { 12, "Бизнес-анализ" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "CompetencyTranslations",
                columns: new[] { "Id", "CompetencyId", "LanguageCode", "Name" },
                values: new object[,]
                {
                    { 1, 1, "ru-RU", "Эффективная коммуникация" },
                    { 2, 1, "en-US", "Effective Communication" },
                    { 3, 1, "ky-KG", "Натыйжалуу баарлашуу" },
                    { 4, 2, "ru-RU", "Клиентоориентированность" },
                    { 5, 2, "en-US", "Customer Focus" },
                    { 6, 2, "ky-KG", "Кардарга багытталуу" },
                    { 7, 3, "ru-RU", "Умение работать в команде" },
                    { 8, 3, "en-US", "Teamwork" },
                    { 9, 3, "ky-KG", "Командалык иш" },
                    { 10, 4, "ru-RU", "Ориентация на результат" },
                    { 11, 4, "en-US", "Result Orientation" },
                    { 12, 4, "ky-KG", "Жыйынтыкка багытталуу" },
                    { 13, 5, "ru-RU", "Негативный настрой (пессимизм)" },
                    { 14, 5, "en-US", "Negative Attitude (Pessimism)" },
                    { 15, 5, "ky-KG", "Терс маанай (пессимизм)" },
                    { 16, 6, "ru-RU", "Равнодушие" },
                    { 17, 6, "en-US", "Indifference" },
                    { 18, 6, "ky-KG", "Кайдыгерлик" },
                    { 19, 7, "ru-RU", "Лицемерие" },
                    { 20, 7, "en-US", "Hypocrisy" },
                    { 21, 7, "ky-KG", "Экөө сүйлөөчүлүк" },
                    { 22, 8, "ru-RU", "Лидерство" },
                    { 23, 8, "en-US", "Leadership" },
                    { 24, 8, "ky-KG", "Лидерлик" },
                    { 25, 9, "ru-RU", "Надежность / Стабильность" },
                    { 26, 9, "en-US", "Reliability / Stability" },
                    { 27, 9, "ky-KG", "Ишенимдүүлүк / Туруктуулук" },
                    { 28, 10, "ru-RU", "Развитие бизнеса / Партнерство" },
                    { 29, 10, "en-US", "Business Development / Partnership" },
                    { 30, 10, "ky-KG", "Бизнес өнүктүрүү / Өнөктөш" },
                    { 31, 11, "ru-RU", "Креативное мышление" },
                    { 32, 11, "en-US", "Creative Thinking" },
                    { 33, 11, "ky-KG", "Креативдүү ой жүгүртүү" },
                    { 34, 12, "ru-RU", "Стратегическое мышление" },
                    { 35, 12, "en-US", "Strategic Thinking" },
                    { 36, 12, "ky-KG", "Стратегиялык ой жүгүртүү" },
                    { 37, 13, "ru-RU", "Самоорганизация" },
                    { 38, 13, "en-US", "Self-Organization" },
                    { 39, 13, "ky-KG", "Өзүн-өзү уюштуруу" }
                });

            migrationBuilder.InsertData(
                table: "EducationLevelTranslation",
                columns: new[] { "Id", "EducationLevelId", "LanguageCode", "Name" },
                values: new object[,]
                {
                    { 1, 1, "ru-RU", "Высшее законченное (Магистр)" },
                    { 2, 1, "en-US", "Higher Education (Master)" },
                    { 3, 1, "ky-KG", "Жогорку билим (Магистр)" },
                    { 4, 2, "ru-RU", "Среднее специальное / профессиональное" },
                    { 5, 2, "en-US", "Specialized Secondary / Professional" },
                    { 6, 2, "ky-KG", "Орточо кесиптик билим" },
                    { 7, 3, "ru-RU", "Кандидат наук" },
                    { 8, 3, "en-US", "Candidate of Sciences" },
                    { 9, 3, "ky-KG", "Илим кандидаты" },
                    { 10, 4, "ru-RU", "Доктор наук" },
                    { 11, 4, "en-US", "Doctor of Sciences" },
                    { 12, 4, "ky-KG", "Илим доктору" },
                    { 13, 5, "ru-RU", "Доцент" },
                    { 14, 5, "en-US", "Associate Professor" },
                    { 15, 5, "ky-KG", "Ассистент профессор" }
                });

            migrationBuilder.InsertData(
                table: "LanguageTranslations",
                columns: new[] { "Id", "LanguageCode", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "ru-RU", 1, "Английский" },
                    { 2, "en-US", 1, "English" },
                    { 3, "kg-KG", 1, "Англисче" },
                    { 4, "ru-RU", 2, "Турецкий" },
                    { 5, "en-US", 2, "Turkish" },
                    { 6, "kg-KG", 2, "Түркчө" },
                    { 7, "ru-RU", 3, "Немецкий" },
                    { 8, "en-US", 3, "German" },
                    { 9, "kg-KG", 3, "Немисче" },
                    { 10, "ru-RU", 4, "Китайский" },
                    { 11, "en-US", 4, "Chinese" },
                    { 12, "kg-KG", 4, "Кытайча" },
                    { 13, "ru-RU", 5, "Испанский" },
                    { 14, "en-US", 5, "Spanish" },
                    { 15, "kg-KG", 5, "Испанча" },
                    { 16, "ru-RU", 6, "Французский" },
                    { 17, "en-US", 6, "French" },
                    { 18, "kg-KG", 6, "Французча" },
                    { 19, "ru-RU", 7, "Итальянский" },
                    { 20, "en-US", 7, "Italian" },
                    { 21, "kg-KG", 7, "Итальяныча" },
                    { 22, "ru-RU", 8, "Португальский" },
                    { 23, "en-US", 8, "Portuguese" },
                    { 24, "kg-KG", 8, "Португалча" },
                    { 25, "ru-RU", 9, "Русский" },
                    { 26, "en-US", 9, "Russian" },
                    { 27, "kg-KG", 9, "Орусча" },
                    { 28, "ru-RU", 10, "Японский" },
                    { 29, "en-US", 10, "Japanese" },
                    { 30, "kg-KG", 10, "Жапонча" },
                    { 31, "ru-RU", 11, "Корейский" },
                    { 32, "en-US", 11, "Korean" },
                    { 33, "kg-KG", 11, "Кореяча" },
                    { 34, "ru-RU", 12, "Арабский" },
                    { 35, "en-US", 12, "Arabic" },
                    { 36, "kg-KG", 12, "Арабча" },
                    { 37, "ru-RU", 13, "Голландский" },
                    { 38, "en-US", 13, "Dutch" },
                    { 39, "kg-KG", 13, "Голландча" },
                    { 40, "ru-RU", 14, "Греческий" },
                    { 41, "en-US", 14, "Greek" },
                    { 42, "kg-KG", 14, "Грекче" },
                    { 43, "ru-RU", 15, "Хинди" },
                    { 44, "en-US", 15, "Hindi" },
                    { 45, "kg-KG", 15, "Хиндиче" },
                    { 46, "ru-RU", 16, "Шведский" },
                    { 47, "en-US", 16, "Swedish" },
                    { 48, "kg-KG", 16, "Шведче" },
                    { 49, "ru-RU", 17, "Норвежский" },
                    { 50, "en-US", 17, "Norwegian" },
                    { 51, "kg-KG", 17, "Норвегче" },
                    { 52, "ru-RU", 18, "Датский" },
                    { 53, "en-US", 18, "Danish" },
                    { 54, "kg-KG", 18, "Данияча" },
                    { 55, "ru-RU", 19, "Финский" },
                    { 56, "en-US", 19, "Finnish" },
                    { 57, "kg-KG", 19, "Финче" },
                    { 58, "ru-RU", 20, "Польский" },
                    { 59, "en-US", 20, "Polish" },
                    { 60, "kg-KG", 20, "Полякча" },
                    { 61, "ru-RU", 21, "Чешский" },
                    { 62, "en-US", 21, "Czech" },
                    { 63, "kg-KG", 21, "Чехче" },
                    { 64, "ru-RU", 22, "Словацкий" },
                    { 65, "en-US", 22, "Slovak" },
                    { 66, "kg-KG", 22, "Словакча" },
                    { 67, "ru-RU", 23, "Украинский" },
                    { 68, "en-US", 23, "Ukrainian" },
                    { 69, "kg-KG", 23, "Украинча" },
                    { 70, "ru-RU", 24, "Белорусский" },
                    { 71, "en-US", 24, "Belarusian" },
                    { 72, "kg-KG", 24, "Белорусча" },
                    { 73, "ru-RU", 25, "Венгерский" },
                    { 74, "en-US", 25, "Hungarian" },
                    { 75, "kg-KG", 25, "Венгриче" },
                    { 76, "ru-RU", 26, "Румынский" },
                    { 77, "en-US", 26, "Romanian" },
                    { 78, "kg-KG", 26, "Румынияча" },
                    { 79, "ru-RU", 27, "Болгарский" },
                    { 80, "en-US", 27, "Bulgarian" },
                    { 81, "kg-KG", 27, "Болгарча" },
                    { 82, "ru-RU", 28, "Сербский" },
                    { 83, "en-US", 28, "Serbian" },
                    { 84, "kg-KG", 28, "Сербче" },
                    { 85, "ru-RU", 29, "Хорватский" },
                    { 86, "en-US", 29, "Croatian" },
                    { 87, "kg-KG", 29, "Хорватча" },
                    { 88, "ru-RU", 30, "Словенский" },
                    { 89, "en-US", 30, "Slovenian" },
                    { 90, "kg-KG", 30, "Словенча" },
                    { 91, "ru-RU", 31, "Литовский" },
                    { 92, "en-US", 31, "Lithuanian" },
                    { 93, "kg-KG", 31, "Литвача" },
                    { 94, "ru-RU", 32, "Латышский" },
                    { 95, "en-US", 32, "Latvian" },
                    { 96, "kg-KG", 32, "Латышча" },
                    { 97, "ru-RU", 33, "Эстонский" },
                    { 98, "en-US", 33, "Estonian" },
                    { 99, "kg-KG", 33, "Эстонча" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatusTranslations",
                columns: new[] { "Id", "LanguageCode", "MaritalStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "en-US", 1, "Married" },
                    { 2, "ky-KG", 1, "Күйөөм (Замужем)" },
                    { 3, "ru-RU", 1, "Женат/Замужем" },
                    { 4, "en-US", 2, "Single" },
                    { 5, "ky-KG", 2, "Бекар" },
                    { 6, "ru-RU", 2, "Холост/Не замужем" },
                    { 7, "en-US", 3, "Divorced" },
                    { 8, "ky-KG", 3, "Ажыратылган" },
                    { 9, "ru-RU", 3, "Разведен(а)" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "SpecializationId" },
                values: new object[,]
                {
                    { 1, "JavaScript Разработчик", 1 },
                    { 2, "HTML/CSS Разработчик", 1 },
                    { 3, "C# Разработчик", 2 },
                    { 4, "Java Разработчик", 2 },
                    { 5, "Специалист по данным", 3 },
                    { 6, "Аналитик данных", 3 },
                    { 7, "Инженер машинного обучения", 4 },
                    { 8, "Исследователь ИИ", 4 },
                    { 9, "DevOps инженер", 5 },
                    { 10, "Облачный инженер", 5 },
                    { 11, "Swift Разработчик", 6 },
                    { 12, "Android Разработчик", 6 },
                    { 13, "Специалист по кибербезопасности", 7 },
                    { 14, "Этический хакер", 7 },
                    { 15, "Scrum-мастер", 8 },
                    { 16, "Владелец продукта", 8 },
                    { 17, "Сетевой инженер", 9 },
                    { 18, "Администратор сети", 9 },
                    { 19, "Администратор базы данных", 10 },
                    { 20, "Менеджер информационных систем", 10 },
                    { 21, "UI/UX дизайнер", 11 },
                    { 22, "Веб-дизайнер", 11 },
                    { 23, "Бизнес-аналитик", 12 },
                    { 24, "Консультант по бизнес-анализу", 12 }
                });

            migrationBuilder.InsertData(
                table: "SpecializationsTranslation",
                columns: new[] { "Id", "LanguageCode", "Name", "SpecializationId" },
                values: new object[,]
                {
                    { 1, "ru-RU", "Разработка FrontEnd", 1 },
                    { 2, "en-US", "FrontEnd Development", 1 },
                    { 3, "ky-KG", "FrontEnd иштеп чыгуу", 1 },
                    { 4, "ru-RU", "Разработка BackEnd", 2 },
                    { 5, "en-US", "BackEnd Development", 2 },
                    { 6, "ky-KG", "BackEnd иштеп чыгуу", 2 },
                    { 7, "ru-RU", "Наука о данных и аналитика", 3 },
                    { 8, "en-US", "Data Science and Analysis", 3 },
                    { 9, "ky-KG", "Маалымат илими жана аналитика", 3 },
                    { 10, "ru-RU", "Машинное обучение и ИИ", 4 },
                    { 11, "en-US", "Machine Learning and AI", 4 },
                    { 12, "ky-KG", "Машина үйрөнүү жана ЖИ", 4 },
                    { 13, "ru-RU", "DevOps и облачные технологии", 5 },
                    { 14, "en-US", "DevOps and Cloud Engineering", 5 },
                    { 15, "ky-KG", "DevOps жана булут технологиялары", 5 },
                    { 16, "ru-RU", "Мобильная разработка", 6 },
                    { 17, "en-US", "Mobile Development", 6 },
                    { 18, "ky-KG", "Мобилдик иштеп чыгуу", 6 },
                    { 19, "ru-RU", "Кибербезопасность", 7 },
                    { 20, "en-US", "Cybersecurity", 7 },
                    { 21, "ky-KG", "Киберкоопсуздук", 7 },
                    { 22, "ru-RU", "Управление проектами и продуктами", 8 },
                    { 23, "en-US", "Project and Product Management", 8 },
                    { 24, "ky-KG", "Долбоорлорду жана продуктуларды башкаруу", 8 },
                    { 25, "ru-RU", "Сетевые технологии и поддержка ИТ", 9 },
                    { 26, "en-US", "Networking and IT Support", 9 },
                    { 27, "ky-KG", "Тармактык технологиялар жана IT колдоо", 9 },
                    { 28, "ru-RU", "Управление базами данных", 10 },
                    { 29, "en-US", "Database Management", 10 },
                    { 30, "ky-KG", "Маалымат базасын башкаруу", 10 },
                    { 31, "ru-RU", "Дизайн UI/UX", 11 },
                    { 32, "en-US", "UI/UX Design", 11 },
                    { 33, "ky-KG", "UI/UX Дизайн", 11 },
                    { 34, "ru-RU", "Бизнес-анализ", 12 },
                    { 35, "en-US", "Business Analysis", 12 },
                    { 36, "ky-KG", "Бизнес анализ", 12 }
                });

            migrationBuilder.InsertData(
                table: "SkillTranslation",
                columns: new[] { "Id", "LanguageCode", "Name", "SkillId" },
                values: new object[,]
                {
                    { 1, "ru-RU", "JavaScript Разработчик", 1 },
                    { 2, "en-US", "JavaScript Developer", 1 },
                    { 3, "ky-KG", "JavaScript иштеп чыгуучу", 1 },
                    { 4, "ru-RU", "HTML/CSS Разработчик", 2 },
                    { 5, "en-US", "HTML/CSS Developer", 2 },
                    { 6, "ky-KG", "HTML/CSS иштеп чыгуучу", 2 },
                    { 7, "ru-RU", "C# Разработчик", 3 },
                    { 8, "en-US", "C# Developer", 3 },
                    { 9, "ky-KG", "C# иштеп чыгуучу", 3 },
                    { 10, "ru-RU", "Java Разработчик", 4 },
                    { 11, "en-US", "Java Developer", 4 },
                    { 12, "ky-KG", "Java иштеп чыгуучу", 4 },
                    { 13, "ru-RU", "Специалист по данным", 5 },
                    { 14, "en-US", "Data Specialist", 5 },
                    { 15, "ky-KG", "Маалыматтар боюнча адис", 5 },
                    { 16, "ru-RU", "Аналитик данных", 6 },
                    { 17, "en-US", "Data Analyst", 6 },
                    { 18, "ky-KG", "Маалыматтар аналитиги", 6 },
                    { 19, "ru-RU", "Инженер машинного обучения", 7 },
                    { 20, "en-US", "Machine Learning Engineer", 7 },
                    { 21, "ky-KG", "Машиналык үйрөнүү инженери", 7 },
                    { 22, "ru-RU", "Исследователь ИИ", 8 },
                    { 23, "en-US", "AI Researcher", 8 },
                    { 24, "ky-KG", "ИИ изилдөөчүсү", 8 },
                    { 25, "ru-RU", "DevOps инженер", 9 },
                    { 26, "en-US", "DevOps Engineer", 9 },
                    { 27, "ky-KG", "DevOps инженери", 9 },
                    { 28, "ru-RU", "Облачный инженер", 10 },
                    { 29, "en-US", "Cloud Engineer", 10 },
                    { 30, "ky-KG", "Булут инженери", 10 },
                    { 31, "ru-RU", "Swift Разработчик", 11 },
                    { 32, "en-US", "Swift Developer", 11 },
                    { 33, "ky-KG", "Swift иштеп чыгуучу", 11 },
                    { 34, "ru-RU", "Android Разработчик", 12 },
                    { 35, "en-US", "Android Developer", 12 },
                    { 36, "ky-KG", "Android иштеп чыгуучу", 12 },
                    { 37, "ru-RU", "Специалист по кибербезопасности", 13 },
                    { 38, "en-US", "Cybersecurity Specialist", 13 },
                    { 39, "ky-KG", "Киберкоопсуздук адиси", 13 },
                    { 40, "ru-RU", "Этический хакер", 14 },
                    { 41, "en-US", "Ethical Hacker", 14 },
                    { 42, "ky-KG", "Этикалык хакер", 14 },
                    { 43, "ru-RU", "Scrum-мастер", 15 },
                    { 44, "en-US", "Scrum Master", 15 },
                    { 45, "ky-KG", "Scrum мастер", 15 },
                    { 46, "ru-RU", "Владелец продукта", 16 },
                    { 47, "en-US", "Product Owner", 16 },
                    { 48, "ky-KG", "Продукт ээси", 16 },
                    { 49, "ru-RU", "Сетевой инженер", 17 },
                    { 50, "en-US", "Network Engineer", 17 },
                    { 51, "ky-KG", "Тармак инженери", 17 },
                    { 52, "ru-RU", "Администратор сети", 18 },
                    { 53, "en-US", "Network Administrator", 18 },
                    { 54, "ky-KG", "Тармак администратору", 18 },
                    { 55, "ru-RU", "Администратор базы данных", 19 },
                    { 56, "en-US", "Database Administrator", 19 },
                    { 57, "ky-KG", "Маалыматтар базасынын администратору", 19 },
                    { 58, "ru-RU", "Менеджер информационных систем", 20 },
                    { 59, "en-US", "Information Systems Manager", 20 },
                    { 60, "ky-KG", "Маалымат системаларынын менеджери", 20 },
                    { 61, "ru-RU", "UI/UX дизайнер", 21 },
                    { 62, "en-US", "UI/UX Designer", 21 },
                    { 63, "ky-KG", "UI/UX дизайнер", 21 },
                    { 64, "ru-RU", "Веб-дизайнер", 22 },
                    { 65, "en-US", "Web Designer", 22 },
                    { 66, "ky-KG", "Веб-дизайнер", 22 },
                    { 67, "ru-RU", "Бизнес-аналитик", 23 },
                    { 68, "en-US", "Business Analyst", 23 },
                    { 69, "ky-KG", "Бизнес аналитик", 23 },
                    { 70, "ru-RU", "Консультант по бизнес-анализу", 24 },
                    { 71, "en-US", "Business Analysis Consultant", 24 },
                    { 72, "ky-KG", "Бизнес-аналитика боюнча кеңешчи", 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompetencyTranslations_CompetencyId",
                table: "CompetencyTranslations",
                column: "CompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevelTranslation_EducationLevelId",
                table: "EducationLevelTranslation",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyStatuses_MaritalStatusId",
                table: "FamilyStatuses",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyStatuses_UserProfileId",
                table: "FamilyStatuses",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTranslations_LanguageId",
                table: "LanguageTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatusTranslations_MaritalStatusId",
                table: "MaritalStatusTranslations",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AssignedUserProfileId",
                table: "Orders",
                column: "AssignedUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SpecializationId",
                table: "Skills",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTranslation_SkillId",
                table: "SkillTranslation",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationsTranslation_SpecializationId",
                table: "SpecializationsTranslation",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileCompetencies_CompetencyId",
                table: "UserProfileCompetencies",
                column: "CompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileCompetencies_UserProfileId",
                table: "UserProfileCompetencies",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileEducations_EducationLevelId",
                table: "UserProfileEducations",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileEducations_UserProfileId",
                table: "UserProfileEducations",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileLanguages_LanguageId",
                table: "UserProfileLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileLanguages_UserProfileId",
                table: "UserProfileLanguages",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileSkills_SkillId",
                table: "UserProfileSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileSkills_UserProfileId",
                table: "UserProfileSkills",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_UserProfileId",
                table: "WorkExperiences",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CompetencyTranslations");

            migrationBuilder.DropTable(
                name: "EducationLevelTranslation");

            migrationBuilder.DropTable(
                name: "FamilyStatuses");

            migrationBuilder.DropTable(
                name: "LanguageTranslations");

            migrationBuilder.DropTable(
                name: "MaritalStatusTranslations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SkillTranslation");

            migrationBuilder.DropTable(
                name: "SpecializationsTranslation");

            migrationBuilder.DropTable(
                name: "UserProfileCompetencies");

            migrationBuilder.DropTable(
                name: "UserProfileEducations");

            migrationBuilder.DropTable(
                name: "UserProfileLanguages");

            migrationBuilder.DropTable(
                name: "UserProfileSkills");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Competencies");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
