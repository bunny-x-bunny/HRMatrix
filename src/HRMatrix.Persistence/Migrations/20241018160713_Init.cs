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
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
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
                    AdditionalSkills = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AdditionalCompetences = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VideoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "c2e564d5-1690-430e-b523-3bf0fb7cce88", "user@mail.com", false, false, null, "USER@MAIL.COM", "USER", "AQAAAAIAAYagAAAAEGPnCm9NsKGtd7tnte6LRbkhQIioWz1mUE1pUQxuEBFfSGoE2sTex75KDCxlC1ra8w==", null, false, "cce93891-f06d-4efc-a2f0-36350ba20a5c", false, "user" },
                    { 2, 0, "420e1f6f-4090-48f5-b52e-50ac9f2081fb", "superuser@mail.com", false, false, null, "SUPERUSER@MAIL.COM", "SUPERUSER", "AQAAAAIAAYagAAAAEOu2DdkjkK9z+slQsg1GB50ivJA4DJOabj8hTfEeLTzj9EQDZ1GvpDapH3jrpyKQZA==", null, false, "81f25803-2e90-4f28-9fd5-38ece42fac23", false, "superuser" },
                    { 3, 0, "70cd7a4e-e7a8-44e6-99c5-ee5a44ed523f", "hr@mail.com", false, false, null, "HR@MAIL.COM", "HR", "AQAAAAIAAYagAAAAEA/XK/hZ8c4+ycTQlyY3V2SgSNer2F4HbFPJCDvRoNjrtpofpBDJGlO8LyvT/bnyFw==", null, false, "ed455a1e-a3c6-4db3-9fc8-fb244e9ca8f7", false, "hr" },
                    { 4, 0, "db00d3be-e47d-496d-975d-ff820eaf718e", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEEoP3wE70mrEjdY6X54PyWwPKnIFY1qiVFhckfu2YMJQadG8M/bxGwpZwRZpuK99qw==", null, false, "d017d803-fc8e-4498-b6df-354f2cd6ca29", false, "admin" }
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
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C# Разработчик" },
                    { 2, "Java Разработчик" },
                    { 3, "Python Разработчик" },
                    { 4, "JavaScript Разработчик" },
                    { 5, "Ruby Разработчик" },
                    { 6, "PHP Разработчик" },
                    { 7, "Swift Разработчик" },
                    { 8, "Go Разработчик" },
                    { 9, "C++ Разработчик" },
                    { 10, "C Разработчик" },
                    { 11, "TypeScript Разработчик" },
                    { 12, "HTML/CSS Разработчик" },
                    { 13, "SQL Разработчик" },
                    { 14, "Специалист по данным" },
                    { 15, "Аналитик данных" },
                    { 16, "Инженер машинного обучения" },
                    { 17, "DevOps инженер" },
                    { 18, "Мобильный разработчик" },
                    { 19, "Облачный инженер" },
                    { 20, "Блокчейн разработчик" },
                    { 21, "Специалист по кибербезопасности" },
                    { 22, "Администратор сети" },
                    { 23, "Системный администратор" },
                    { 24, "Веб-дизайнер" },
                    { 25, "UI/UX дизайнер" },
                    { 26, "Разработчик игр" },
                    { 27, "Full-Stack Разработчик" },
                    { 28, "Инженер-программист" },
                    { 29, "Scrum-мастер" },
                    { 30, "Владелец продукта" },
                    { 31, "Технический писатель" },
                    { 32, "SEO специалист" },
                    { 33, "Контент менеджер" },
                    { 34, "Бизнес-аналитик" },
                    { 35, "Руководитель проекта" },
                    { 36, "Инженер по обеспечению качества" },
                    { 37, "Тестировщик программного обеспечения" },
                    { 38, "Веб-разработчик" },
                    { 39, "Специалист по поддержке ИТ" },
                    { 40, "Инженер по аппаратному обеспечению" },
                    { 41, "ИТ-консультант" },
                    { 42, "Специалист по ГИС" },
                    { 43, "Специалист по электронной коммерции" },
                    { 44, "Маркетолог" },
                    { 45, "Специалист по цифровому маркетингу" },
                    { 46, "Менеджер по социальным сетям" },
                    { 47, "Дизайнер видеоигр" },
                    { 48, "Администратор базы данных" },
                    { 49, "Менеджер информационных систем" },
                    { 50, "Офицер по соответствию" },
                    { 51, "Этический хакер" },
                    { 52, "Разработчик веб-приложений" },
                    { 53, "Разработчик API" },
                    { 54, "Инженер технической поддержки" },
                    { 55, "Координатор проекта ИТ" },
                    { 56, "Системный аналитик" },
                    { 57, "Архитектор предприятия" },
                    { 58, "ИТ-аудитор" },
                    { 59, "Разработчик мобильных игр" },
                    { 60, "Разработчик AR/VR" },
                    { 61, "Инженер-робототехник" },
                    { 62, "Специалист по техническому SEO" },
                    { 63, "Стратег контента" },
                    { 64, "Специалист по интеграции систем" },
                    { 65, "Тренер по ИТ" },
                    { 66, "Эксперт по криптографии" },
                    { 67, "UI-разработчик" },
                    { 68, "Исследователь UX" },
                    { 69, "Инженер данных" },
                    { 70, "Исследователь ИИ" },
                    { 71, "Тестировщик игр" },
                    { 72, "Тестировщик на проникновение" },
                    { 73, "Менеджер продукта" },
                    { 74, "Сетевой инженер" },
                    { 75, "Специалист по телекоммуникациям" },
                    { 76, "Инженер по встроенному ПО" },
                    { 77, "Архитектор облачных решений" },
                    { 78, "Аналитик бизнес-разведки" },
                    { 79, "Статистический аналитик" },
                    { 80, "Исследователь машинного обучения" },
                    { 81, "Специалист по визуализации данных" },
                    { 82, "Аналитик информационной безопасности" },
                    { 83, "Аналитик по соответствию ИТ" },
                    { 84, "Телекоммуникационный аналитик" },
                    { 85, "Операционный аналитик" },
                    { 86, "Менеджер программы" },
                    { 87, "Специалист по безопасности веб-сайта" },
                    { 88, "Специалист по здравоохранению ИТ" },
                    { 89, "Менеджер по рискам ИТ" },
                    { 90, "Специалист по искусственному интеллекту" },
                    { 91, "Офицер по защите данных" },
                    { 92, "Системный инженер" },
                    { 93, "Архитектор интеграции" }
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
                table: "SkillTranslation",
                columns: new[] { "Id", "LanguageCode", "Name", "SkillId" },
                values: new object[,]
                {
                    { 1, "ru-RU", "C# Разработчик", 1 },
                    { 2, "en-US", "C# Developer", 1 },
                    { 3, "ky-KG", "C# программист", 1 },
                    { 4, "ru-RU", "Java Разработчик", 2 },
                    { 5, "en-US", "Java Developer", 2 },
                    { 6, "ky-KG", "Java программист", 2 },
                    { 7, "ru-RU", "Python Разработчик", 3 },
                    { 8, "en-US", "Python Developer", 3 },
                    { 9, "ky-KG", "Python программист", 3 },
                    { 10, "ru-RU", "JavaScript Разработчик", 4 },
                    { 11, "en-US", "JavaScript Developer", 4 },
                    { 12, "ky-KG", "JavaScript программист", 4 },
                    { 13, "ru-RU", "Ruby Разработчик", 5 },
                    { 14, "en-US", "Ruby Developer", 5 },
                    { 15, "ky-KG", "Ruby программист", 5 },
                    { 16, "ru-RU", "PHP Разработчик", 6 },
                    { 17, "en-US", "PHP Developer", 6 },
                    { 18, "ky-KG", "PHP программист", 6 },
                    { 19, "ru-RU", "Swift Разработчик", 7 },
                    { 20, "en-US", "Swift Developer", 7 },
                    { 21, "ky-KG", "Swift программист", 7 },
                    { 22, "ru-RU", "Go Разработчик", 8 },
                    { 23, "en-US", "Go Developer", 8 },
                    { 24, "ky-KG", "Go программист", 8 },
                    { 25, "ru-RU", "C++ Разработчик", 9 },
                    { 26, "en-US", "C++ Developer", 9 },
                    { 27, "ky-KG", "C++ программист", 9 },
                    { 28, "ru-RU", "C Разработчик", 10 },
                    { 29, "en-US", "C Developer", 10 },
                    { 30, "ky-KG", "C программист", 10 },
                    { 31, "ru-RU", "TypeScript Разработчик", 11 },
                    { 32, "en-US", "TypeScript Developer", 11 },
                    { 33, "ky-KG", "TypeScript программист", 11 },
                    { 34, "ru-RU", "HTML/CSS Разработчик", 12 },
                    { 35, "en-US", "HTML/CSS Developer", 12 },
                    { 36, "ky-KG", "HTML/CSS программист", 12 },
                    { 37, "ru-RU", "SQL Разработчик", 13 },
                    { 38, "en-US", "SQL Developer", 13 },
                    { 39, "ky-KG", "SQL программист", 13 },
                    { 40, "ru-RU", "Data Scientist", 14 },
                    { 41, "en-US", "Data Scientist", 14 },
                    { 42, "ky-KG", "Data Scientist", 14 },
                    { 43, "ru-RU", "Аналитик данных", 15 },
                    { 44, "en-US", "Data Analyst", 15 },
                    { 45, "ky-KG", "Аналитик маалыматтары", 15 },
                    { 46, "ru-RU", "Инженер машинного обучения", 16 },
                    { 47, "en-US", "Machine Learning Engineer", 16 },
                    { 48, "ky-KG", "Машиналык үйрөнүү инженери", 16 },
                    { 49, "ru-RU", "DevOps инженер", 17 },
                    { 50, "en-US", "DevOps Engineer", 17 },
                    { 51, "ky-KG", "DevOps инженер", 17 },
                    { 52, "ru-RU", "Мобильный разработчик", 18 },
                    { 53, "en-US", "Mobile App Developer", 18 },
                    { 54, "ky-KG", "Мобилдик колдонмо иштеп чыгуучу", 18 },
                    { 55, "ru-RU", "Облачный инженер", 19 },
                    { 56, "en-US", "Cloud Engineer", 19 },
                    { 57, "ky-KG", "Булут инженери", 19 },
                    { 58, "ru-RU", "Блокчейн разработчик", 20 },
                    { 59, "en-US", "Blockchain Developer", 20 },
                    { 60, "ky-KG", "Блокчейн иштеп чыгуучу", 20 },
                    { 61, "ru-RU", "Специалист по кибербезопасности", 21 },
                    { 62, "en-US", "Cybersecurity Specialist", 21 },
                    { 63, "ky-KG", "Киберкоопсуздук адиси", 21 },
                    { 64, "ru-RU", "Администратор сети", 22 },
                    { 65, "en-US", "Network Administrator", 22 },
                    { 66, "ky-KG", "Тармак администратору", 22 },
                    { 67, "ru-RU", "Системный администратор", 23 },
                    { 68, "en-US", "System Administrator", 23 },
                    { 69, "ky-KG", "Системалык администратор", 23 },
                    { 70, "ru-RU", "Веб-дизайнер", 24 },
                    { 71, "en-US", "Web Designer", 24 },
                    { 72, "ky-KG", "Веб-дизайнер", 24 },
                    { 73, "ru-RU", "UI/UX дизайнер", 25 },
                    { 74, "en-US", "UI/UX Designer", 25 },
                    { 75, "ky-KG", "UI/UX дизайнер", 25 },
                    { 76, "ru-RU", "Разработчик игр", 26 },
                    { 77, "en-US", "Game Developer", 26 },
                    { 78, "ky-KG", "Оюн иштеп чыгуучу", 26 },
                    { 79, "ru-RU", "Full-Stack Разработчик", 27 },
                    { 80, "en-US", "Full-Stack Developer", 27 },
                    { 81, "ky-KG", "Full-Stack иштеп чыгуучу", 27 },
                    { 82, "ru-RU", "Инженер-программист", 28 },
                    { 83, "en-US", "Software Engineer", 28 },
                    { 84, "ky-KG", "Программалык камсыздоо инженери", 28 },
                    { 85, "ru-RU", "Scrum-мастер", 29 },
                    { 86, "en-US", "Scrum Master", 29 },
                    { 87, "ky-KG", "Scrum мастер", 29 },
                    { 88, "ru-RU", "Владелец продукта", 30 },
                    { 89, "en-US", "Product Owner", 30 },
                    { 90, "ky-KG", "Продукт ээси", 30 },
                    { 91, "ru-RU", "Технический писатель", 31 },
                    { 92, "en-US", "Technical Writer", 31 },
                    { 93, "ky-KG", "Техникалык жазуучу", 31 },
                    { 94, "ru-RU", "SEO специалист", 32 },
                    { 95, "en-US", "SEO Specialist", 32 },
                    { 96, "ky-KG", "SEO адиси", 32 },
                    { 97, "ru-RU", "Контент менеджер", 33 },
                    { 98, "en-US", "Content Manager", 33 },
                    { 99, "ky-KG", "Мазмун менеджери", 33 },
                    { 100, "ru-RU", "Бизнес-аналитик", 34 },
                    { 101, "en-US", "Business Analyst", 34 },
                    { 102, "ky-KG", "Бизнес аналитик", 34 },
                    { 103, "ru-RU", "Руководитель проекта", 35 },
                    { 104, "en-US", "Project Manager", 35 },
                    { 105, "ky-KG", "Долбоор менеджери", 35 },
                    { 106, "ru-RU", "Инженер по обеспечению качества", 36 },
                    { 107, "en-US", "Quality Assurance Engineer", 36 },
                    { 108, "ky-KG", "Сапатты камсыздоо инженери", 36 },
                    { 109, "ru-RU", "Тестировщик программного обеспечения", 37 },
                    { 110, "en-US", "Software Tester", 37 },
                    { 111, "ky-KG", "Программалык камсыздоо тестери", 37 },
                    { 112, "ru-RU", "Веб-разработчик", 38 },
                    { 113, "en-US", "Web Developer", 38 },
                    { 114, "ky-KG", "Веб иштеп чыгуучу", 38 },
                    { 115, "ru-RU", "Специалист по поддержке ИТ", 39 },
                    { 116, "en-US", "IT Support Specialist", 39 },
                    { 117, "ky-KG", "IT колдоо адиси", 39 },
                    { 118, "ru-RU", "Инженер по аппаратному обеспечению", 40 },
                    { 119, "en-US", "Hardware Engineer", 40 },
                    { 120, "ky-KG", "Аппараттык камсыздоо инженери", 40 },
                    { 121, "ru-RU", "ИТ-консультант", 41 },
                    { 122, "en-US", "IT Consultant", 41 },
                    { 123, "ky-KG", "IT консультанты", 41 },
                    { 124, "ru-RU", "Специалист по ГИС", 42 },
                    { 125, "en-US", "GIS Specialist", 42 },
                    { 126, "ky-KG", "ГИС адиси", 42 },
                    { 127, "ru-RU", "Специалист по электронной коммерции", 43 },
                    { 128, "en-US", "E-commerce Specialist", 43 },
                    { 129, "ky-KG", "Электрондук соода адиси", 43 },
                    { 130, "ru-RU", "Маркетолог", 44 },
                    { 131, "en-US", "Marketing Specialist", 44 },
                    { 132, "ky-KG", "Маркетинг адиси", 44 },
                    { 133, "ru-RU", "Специалист по цифровому маркетингу", 45 },
                    { 134, "en-US", "Digital Marketing Specialist", 45 },
                    { 135, "ky-KG", "Санариптик маркетинг адиси", 45 },
                    { 136, "ru-RU", "Менеджер по социальным сетям", 46 },
                    { 137, "en-US", "Social Media Manager", 46 },
                    { 138, "ky-KG", "Социалдык медиа менеджери", 46 },
                    { 139, "ru-RU", "Дизайнер видеоигр", 47 },
                    { 140, "en-US", "Video Game Designer", 47 },
                    { 141, "ky-KG", "Видео оюн дизайнери", 47 },
                    { 142, "ru-RU", "Администратор базы данных", 48 },
                    { 143, "en-US", "Database Administrator", 48 },
                    { 144, "ky-KG", "Маалымат базасынын администратору", 48 },
                    { 145, "ru-RU", "Менеджер информационных систем", 49 },
                    { 146, "en-US", "Information Systems Manager", 49 },
                    { 147, "ky-KG", "Маалымат системаларынын менеджери", 49 },
                    { 148, "ru-RU", "Офицер по соответствию", 50 },
                    { 149, "en-US", "Compliance Officer", 50 },
                    { 150, "ky-KG", "Шайкештик боюнча офицер", 50 },
                    { 151, "ru-RU", "Этический хакер", 51 },
                    { 152, "en-US", "Ethical Hacker", 51 },
                    { 153, "ky-KG", "Этикалык хакер", 51 },
                    { 154, "ru-RU", "Разработчик веб-приложений", 52 },
                    { 155, "en-US", "Web Application Developer", 52 },
                    { 156, "ky-KG", "Веб колдонмо иштеп чыгуучу", 52 },
                    { 157, "ru-RU", "Разработчик API", 53 },
                    { 158, "en-US", "API Developer", 53 },
                    { 159, "ky-KG", "API иштеп чыгуучу", 53 },
                    { 160, "ru-RU", "Инженер технической поддержки", 54 },
                    { 161, "en-US", "Technical Support Engineer", 54 },
                    { 162, "ky-KG", "Техникалык колдоо инженери", 54 },
                    { 163, "ru-RU", "Координатор проекта ИТ", 55 },
                    { 164, "en-US", "IT Project Coordinator", 55 },
                    { 165, "ky-KG", "IT долбоор координатору", 55 },
                    { 166, "ru-RU", "Системный аналитик", 56 },
                    { 167, "en-US", "System Analyst", 56 },
                    { 168, "ky-KG", "Система аналитиги", 56 },
                    { 169, "ru-RU", "Архитектор предприятия", 57 },
                    { 170, "en-US", "Enterprise Architect", 57 },
                    { 171, "ky-KG", "Ишкананын архитектору", 57 },
                    { 172, "ru-RU", "ИТ-аудитор", 58 },
                    { 173, "en-US", "IT Auditor", 58 },
                    { 174, "ky-KG", "IT аудитору", 58 },
                    { 175, "ru-RU", "Разработчик мобильных игр", 59 },
                    { 176, "en-US", "Mobile Game Developer", 59 },
                    { 177, "ky-KG", "Мобилдик оюн иштеп чыгуучу", 59 },
                    { 178, "ru-RU", "Разработчик AR/VR", 60 },
                    { 179, "en-US", "AR/VR Developer", 60 },
                    { 180, "ky-KG", "AR/VR иштеп чыгуучу", 60 },
                    { 181, "ru-RU", "Инженер-робототехник", 61 },
                    { 182, "en-US", "Robotics Engineer", 61 },
                    { 183, "ky-KG", "Робототехника инженери", 61 },
                    { 184, "ru-RU", "Специалист по техническому SEO", 62 },
                    { 185, "en-US", "Technical SEO Specialist", 62 },
                    { 186, "ky-KG", "Техникалык SEO адиси", 62 },
                    { 187, "ru-RU", "Стратег контента", 63 },
                    { 188, "en-US", "Content Strategist", 63 },
                    { 189, "ky-KG", "Мазмун стратегиясы", 63 },
                    { 190, "ru-RU", "Специалист по интеграции систем", 64 },
                    { 191, "en-US", "System Integration Specialist", 64 },
                    { 192, "ky-KG", "Системалык интеграция адиси", 64 },
                    { 193, "ru-RU", "Тренер по ИТ", 65 },
                    { 194, "en-US", "IT Trainer", 65 },
                    { 195, "ky-KG", "IT тренери", 65 },
                    { 196, "ru-RU", "Эксперт по криптографии", 66 },
                    { 197, "en-US", "Cryptography Expert", 66 },
                    { 198, "ky-KG", "Криптография боюнча эксперт", 66 },
                    { 199, "ru-RU", "UI-разработчик", 67 },
                    { 200, "en-US", "UI Developer", 67 },
                    { 201, "ky-KG", "UI иштеп чыгуучу", 67 },
                    { 202, "ru-RU", "Исследователь UX", 68 },
                    { 203, "en-US", "UX Researcher", 68 },
                    { 204, "ky-KG", "UX изилдөөчү", 68 },
                    { 205, "ru-RU", "Инженер данных", 69 },
                    { 206, "en-US", "Data Engineer", 69 },
                    { 207, "ky-KG", "Маалымат инженери", 69 },
                    { 208, "ru-RU", "Исследователь ИИ", 70 },
                    { 209, "en-US", "AI Researcher", 70 },
                    { 210, "ky-KG", "ИИ изилдөөчү", 70 },
                    { 211, "ru-RU", "Тестировщик игр", 71 },
                    { 212, "en-US", "Game Tester", 71 },
                    { 213, "ky-KG", "Оюн тестери", 71 },
                    { 214, "ru-RU", "Тестировщик на проникновение", 72 },
                    { 215, "en-US", "Penetration Tester", 72 },
                    { 216, "ky-KG", "Пенетрация тестери", 72 },
                    { 217, "ru-RU", "Менеджер продукта", 73 },
                    { 218, "en-US", "Product Manager", 73 },
                    { 219, "ky-KG", "Продукт менеджери", 73 },
                    { 220, "ru-RU", "Сетевой инженер", 74 },
                    { 221, "en-US", "Network Engineer", 74 },
                    { 222, "ky-KG", "Тармак инженери", 74 },
                    { 223, "ru-RU", "Специалист по телекоммуникациям", 75 },
                    { 224, "en-US", "Telecommunications Specialist", 75 },
                    { 225, "ky-KG", "Телеком адиси", 75 },
                    { 226, "ru-RU", "Инженер по встроенному ПО", 76 },
                    { 227, "en-US", "Firmware Engineer", 76 },
                    { 228, "ky-KG", "Орнотулган программалык камсыздоо инженери", 76 },
                    { 229, "ru-RU", "Архитектор облачных решений", 77 },
                    { 230, "en-US", "Cloud Solutions Architect", 77 },
                    { 231, "ky-KG", "Булут чечимдеринин архитектору", 77 },
                    { 232, "ru-RU", "Аналитик бизнес-разведки", 78 },
                    { 233, "en-US", "Business Intelligence Analyst", 78 },
                    { 234, "ky-KG", "Бизнес-чалгындоо аналитиги", 78 },
                    { 235, "ru-RU", "Статистический аналитик", 79 },
                    { 236, "en-US", "Statistical Analyst", 79 },
                    { 237, "ky-KG", "Статистикалык аналитик", 79 },
                    { 238, "ru-RU", "Исследователь машинного обучения", 80 },
                    { 239, "en-US", "Machine Learning Researcher", 80 },
                    { 240, "ky-KG", "Машина үйрөнүү изилдөөчүсү", 80 },
                    { 241, "ru-RU", "Специалист по визуализации данных", 81 },
                    { 242, "en-US", "Data Visualization Specialist", 81 },
                    { 243, "ky-KG", "Маалыматтарды визуалдаштыруу адиси", 81 },
                    { 244, "ru-RU", "Аналитик информационной безопасности", 82 },
                    { 245, "en-US", "Information Security Analyst", 82 },
                    { 246, "ky-KG", "Маалымат коопсуздугунун аналитиги", 82 },
                    { 247, "ru-RU", "Аналитик по соответствию ИТ", 83 },
                    { 248, "en-US", "IT Compliance Analyst", 83 },
                    { 249, "ky-KG", "IT шайкештик аналитиги", 83 },
                    { 250, "ru-RU", "Телекоммуникационный аналитик", 84 },
                    { 251, "en-US", "Telecom Analyst", 84 },
                    { 252, "ky-KG", "Телеком аналитик", 84 },
                    { 253, "ru-RU", "Операционный аналитик", 85 },
                    { 254, "en-US", "Operations Analyst", 85 },
                    { 255, "ky-KG", "Операция аналитиги", 85 },
                    { 256, "ru-RU", "Менеджер программы", 86 },
                    { 257, "en-US", "Program Manager", 86 },
                    { 258, "ky-KG", "Программа менеджери", 86 },
                    { 259, "ru-RU", "Специалист по безопасности веб-сайта", 87 },
                    { 260, "en-US", "Web Security Specialist", 87 },
                    { 261, "ky-KG", "Веб коопсуздук адиси", 87 },
                    { 262, "ru-RU", "Специалист по здравоохранению ИТ", 88 },
                    { 263, "en-US", "Health IT Specialist", 88 },
                    { 264, "ky-KG", "Ден-соолук IT адиси", 88 },
                    { 265, "ru-RU", "Менеджер по рискам ИТ", 89 },
                    { 266, "en-US", "IT Risk Manager", 89 },
                    { 267, "ky-KG", "IT коркунуч менеджери", 89 },
                    { 268, "ru-RU", "Специалист по искусственному интеллекту", 90 },
                    { 269, "en-US", "Artificial Intelligence Specialist", 90 },
                    { 270, "ky-KG", "Жасалма интеллект адиси", 90 },
                    { 271, "ru-RU", "Офицер по защите данных", 91 },
                    { 272, "en-US", "Data Privacy Officer", 91 },
                    { 273, "ky-KG", "Маалыматтарды купуялуулук боюнча офицер", 91 },
                    { 274, "ru-RU", "Системный инженер", 92 },
                    { 275, "en-US", "Systems Engineer", 92 },
                    { 276, "ky-KG", "Системалар инженери", 92 },
                    { 277, "ru-RU", "Архитектор интеграции", 93 },
                    { 278, "en-US", "Integration Architect", 93 },
                    { 279, "ky-KG", "Интеграция архитектуру", 93 }
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
                name: "IX_SkillTranslation_SkillId",
                table: "SkillTranslation",
                column: "SkillId");

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
                name: "EducationLevelTranslation");

            migrationBuilder.DropTable(
                name: "FamilyStatuses");

            migrationBuilder.DropTable(
                name: "LanguageTranslations");

            migrationBuilder.DropTable(
                name: "MaritalStatusTranslations");

            migrationBuilder.DropTable(
                name: "SkillTranslation");

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
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
