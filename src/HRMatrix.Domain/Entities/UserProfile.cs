using HRMatrix.IdentityService.Models;

namespace HRMatrix.Domain.Entities;

public class UserProfile
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public ICollection<UserProfileEducation> UserEducations { get; set; }

    public ICollection<UserProfileSkill> UserProfileSkills { get; set; }

    public ICollection<WorkExperience> WorkExperiences { get; set; }

    public ICollection<UserProfileCompetency> UserProfileCompetencies { get; set; }

    public FamilyStatus FamilyStatus { get; set; }

    public ICollection<UserProfileLanguage> UserProfileLanguages { get; set; }

    public string? ProfilePhotoPath { get; set; }

    public string? VideoPath { get; set; }

    public int? AspNetUserId { get; set; }
}

