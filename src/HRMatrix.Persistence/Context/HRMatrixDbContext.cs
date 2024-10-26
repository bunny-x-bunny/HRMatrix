using HRMatrix.Domain.Configurations;
using HRMatrix.Domain.Entities;
using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Persistence.Contexts
{
    public class HRMatrixDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public DbSet<EducationLevel> EducationLevels { get; set; }

        //public DbSet<EducationLevelTranslation> EducationLevelTranslations { get; set; }

        public DbSet<MaritalStatus> MaritalStatuses { get; set; }

        public DbSet<MaritalStatusTranslation> MaritalStatusTranslations { get; set; }

        public DbSet<UserProfileEducation> UserProfileEducations { get; set; }

        public DbSet<UserProfileCompetency> UserProfileCompetencies { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<UserProfileSkill> UserProfileSkills { get; set; }

        public DbSet<WorkExperience> WorkExperiences { get; set; }

        public DbSet<FamilyStatus> FamilyStatuses { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<LanguageTranslation> LanguageTranslations { get; set; }

        public DbSet<UserProfileLanguage> UserProfileLanguages { get; set; }

        public DbSet<Competency> Competencies { get; set; }

        public DbSet<CompetencyTranslation> CompetencyTranslations { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<SpecializationTranslation> SpecializationsTranslation { get; set; }

        public DbSet<Order> Orders { get; set; }

        public HRMatrixDbContext(DbContextOptions<HRMatrixDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserProfileConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationUser).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRMatrixDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
