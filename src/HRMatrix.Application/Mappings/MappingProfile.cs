using AutoMapper;
using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.Languages;
using HRMatrix.Application.DTOs.MaterialStatus;
using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.UserAccount;
using HRMatrix.Application.DTOs.UserProfile;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Application.DTOs.WorkExperiences;
using HRMatrix.Domain.Entities;
using HRMatrix.Application.DTOs.UserProfilesLanguages;
using HRMatrix.IdentityService.Models;
using HRMatrix.Application.DTOs.Competency;
using HRMatrix.Application.DTOs.UserProfileCompetency;
using HRMatrix.Application.DTOs.Order;
using HRMatrix.Application.DTOs.Specialization;
using HRMatrix.Application.DTOs.WorkType;
using HRMatrix.Application.DTOs.Country;
using HRMatrix.Application.DTOs;
using HRMatrix.Application.DTOs.City;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Маппинг для создания UserProfile
        CreateMap<CreateUserProfileDto, UserProfile>()
            .ForMember(dest => dest.FamilyStatus, opt => opt.MapFrom(src => src.FamilyStatus))
            .ForMember(dest => dest.UserEducations, opt => opt.MapFrom(src => src.UserEducations))
            .ForMember(dest => dest.UserProfileSkills, opt => opt.MapFrom(src => src.UserProfileSkills))
            .ForMember(dest => dest.WorkExperiences, opt => opt.MapFrom(src => src.WorkExperiences))
            .ForMember(dest => dest.UserProfileCompetencies, opt => opt.MapFrom(src => src.Competencies))
            .ForMember(dest => dest.UserProfileLanguages, opt => opt.MapFrom(src => src.Languages));
            
        // Маппинг для обновления UserProfile
        CreateMap<UpdateUserProfileDto, UserProfile>()
            .ForMember(dest => dest.UserEducations, opt => opt.MapFrom(src => src.UserEducations))
            .ForMember(dest => dest.FamilyStatus, opt => opt.MapFrom(src => src.FamilyStatus))
            .ForMember(dest => dest.UserProfileSkills, opt => opt.MapFrom(src => src.UserProfileSkills))
            .ForMember(dest => dest.WorkExperiences, opt => opt.MapFrom(src => src.WorkExperiences))
            .ForMember(dest => dest.UserProfileLanguages, opt => opt.MapFrom(src => src.Languages))
            .ForMember(dest => dest.UserProfileCompetencies, opt => opt.MapFrom(src => src.Competencies))
            .ReverseMap();

        // Маппинг для UserProfile и FamilyStatus
        CreateMap<UserProfile, UserProfileDto>()
            .ForMember(dest => dest.FamilyStatus, opt => opt.MapFrom(src => src.FamilyStatus))
            .ForMember(dest => dest.WorkExperiences, opt => opt.MapFrom(src => src.WorkExperiences))
            .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.UserProfileLanguages))
            .ReverseMap();

        // Маппинг для UserProfileLanguage
        CreateMap<UserProfileLanguage, UserProfileLanguageResponse>()
            .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Language.Name))
            .ForMember(dest => dest.ProficiencyLevel, opt => opt.MapFrom(src => src.ProficiencyLevel))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Language.Translations));

        CreateMap<CreateUserProfileLanguageRequest, UserProfileLanguage>()
            .ForMember(dest => dest.UserProfileId, opt => opt.Ignore())
            .ReverseMap();

        // Маппинг для FamilyStatus
        CreateMap<FamilyStatus, FamilyStatusDto>()
            .ForMember(dest => dest.MaritalStatusDescription, opt => opt.MapFrom(src => src.MaritalStatus.Name))
            .ForMember(dest => dest.MaritalStatusTranslations, opt => opt.MapFrom(src => src.MaritalStatus.Translations))
            .ReverseMap();

        CreateMap<CreateFamilyStatusDto, FamilyStatus>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateFamilyStatusDto, FamilyStatus>().ReverseMap();

        CreateMap<MaritalStatus, MaritalStatusDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<MaritalStatusTranslation, MaritalStatusTranslationDto>().ReverseMap();

        // Маппинг для EducationLevel и его переводов
        CreateMap<EducationLevel, EducationLevelDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<EducationLevelTranslation, EducationLevelTranslationDto>().ReverseMap();

        CreateMap<CreateEducationLevelDto, EducationLevel>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        CreateMap<CreateEducationLevelTranslationDto, EducationLevelTranslation>().ReverseMap();

        CreateMap<UpdateEducationLevelDto, EducationLevel>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        CreateMap<UpdateEducationLevelTranslationDto, EducationLevelTranslation>().ReverseMap();

        // Маппинг для уровня образования пользователя
        CreateMap<UserProfileEducation, UserProfileEducationResponse>()
            .ForMember(dest => dest.EducationLevelName, opt => opt.MapFrom(src => src.EducationLevel.Name))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.EducationLevel.Translations));

        CreateMap<EducationLevelTranslation, EducationLevelTranslationDto>().ReverseMap();

        CreateMap<CreateUserProfileEducationRequest, UserProfileEducation>()
            .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
            .ForMember(dest => dest.EducationLevelId, opt => opt.MapFrom(src => src.EducationLevelId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ReverseMap();

        CreateMap<UserEducationEntryRequest, UserProfileEducation>()
            .ForMember(dest => dest.EducationLevelId, opt => opt.MapFrom(src => src.EducationLevelId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ReverseMap();

        // Маппинг для Skill и SkillDto
        CreateMap<Skill, SkillDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<SkillTranslation, SkillTranslationDto>().ReverseMap();

        CreateMap<CreateSkillDto, Skill>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<UpdateSkillDto, Skill>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<SkillTranslation, SkillTranslationDto>().ReverseMap();

        CreateMap<UpdateSkillTranslationDto, SkillTranslation>()
            .ForMember(dest => dest.SkillId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<CreateSkillTranslationDto, SkillTranslation>()
            .ForMember(dest => dest.SkillId, opt => opt.Ignore())
            .ReverseMap();

        // Маппинг для UserProfileSkill
        CreateMap<UserProfileSkill, UserProfileSkillResponse>()
            .ForMember(dest => dest.SkillId, opt => opt.MapFrom(src => src.SkillId))
            .ForMember(dest => dest.ProficiencyLevel, opt => opt.MapFrom(src => src.ProficiencyLevel))
            .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.Name))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Skill.Translations));

        CreateMap<CreateUserProfileSkillsRequest, UserProfileSkill>()
            .ForMember(dest => dest.UserProfileId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateUserProfileSkillsRequest, UserProfileSkill>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<CreateUserProfileSkillRequest, UserProfileSkill>()
            .ForMember(dest => dest.UserProfileId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateUserProfileSkillRequest, UserProfileSkill>()
            .ForMember(dest => dest.UserProfileId, opt => opt.Ignore())
            .ReverseMap();

        // Маппинг для WorkExperience
        CreateMap<CreateWorkExperienceDto, WorkExperience>().ReverseMap();
        CreateMap<WorkExperience, WorkExperienceResponseDto>().ReverseMap();
        CreateMap<CreateWorkExperienceNoIdDto, WorkExperience>().ReverseMap();

        // Маппинг для Language и LanguageDto
        CreateMap<Language, LanguageDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<LanguageTranslation, LanguageTranslationDto>().ReverseMap();

        CreateMap<CreateLanguageDto, Language>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<UpdateLanguageDto, Language>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<CreateLanguageTranslationDto, LanguageTranslation>()
            .ForMember(dest => dest.LanguageId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateLanguageTranslationDto, LanguageTranslation>()
            .ForMember(dest => dest.LanguageId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<PatchUserAccountRequest, ApplicationUser>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<UpdateUserAccountRequest, ApplicationUser>()
            .ReverseMap();

        // Маппинг для Competency и CompetencyDto
        CreateMap<Competency, CompetencyDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<CompetencyTranslation, CompetencyTranslationDto>().ReverseMap();

        CreateMap<CreateCompetencyDto, Competency>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<UpdateCompetencyDto, Competency>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<CreateCompetencyTranslationDto, CompetencyTranslation>()
            .ForMember(dest => dest.CompetencyId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateCompetencyTranslationDto, CompetencyTranslation>()
            .ForMember(dest => dest.CompetencyId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UserProfileCompetency, UserProfileCompetencyResponse>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Competency.Translations))
            .ReverseMap();

        CreateMap<CreateUserProfileCompetencyRequest, UserProfileCompetency>()
            .ForMember(dest => dest.UserProfileId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<CreateUserProfileCompetenciesRequest, UserProfileCompetency>()
            .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
            .ReverseMap();

        // Маппинг для Order и OrderDto
        CreateMap<Order, OrderDto>();

        CreateMap<OrderDto, Order>();

        // Маппинг для создания Order
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.AssignedUserProfile, opt => opt.Ignore());

        // Маппинг для обновления Order
        CreateMap<UpdateOrderDto, Order>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.AssignedUserProfile, opt => opt.Ignore());

        // Маппинг для Specialization и SpecializationDto
        CreateMap<Specialization, SpecializationDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<SpecializationTranslation, SpecializationTranslationDto>().ReverseMap();

        CreateMap<CreateSpecializationDto, Specialization>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<UpdateSpecializationDto, Specialization>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<CreateSpecializationTranslationDto, SpecializationTranslation>()
            .ForMember(dest => dest.SpecializationId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateSpecializationTranslationDto, SpecializationTranslation>()
            .ForMember(dest => dest.SpecializationId, opt => opt.Ignore())
            .ReverseMap();

        // WorkType -> WorkTypeDto и обратно
        CreateMap<WorkType, WorkTypeDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        CreateMap<CreateWorkTypeDto, WorkType>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        CreateMap<UpdateWorkTypeDto, WorkType>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        // WorkTypeTranslation -> WorkTypeTranslationDto
        CreateMap<WorkTypeTranslation, WorkTypeTranslationDto>();
        CreateMap<CreateWorkTypeTranslationDto, WorkTypeTranslation>();
        CreateMap<UpdateWorkTypeTranslationDto, WorkTypeTranslation>();

        // Маппинг для Country и CountryDto
        CreateMap<Country, CountryDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<CountryTranslation, CountryTranslationDto>().ReverseMap();

        CreateMap<CreateCountryDto, Country>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<CreateCountryTranslationDto, CountryTranslation>()
            .ForMember(dest => dest.CountryId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateCountryDto, Country>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<UpdateCountryTranslationDto, CountryTranslation>()
            .ForMember(dest => dest.CountryId, opt => opt.Ignore())
            .ReverseMap();

        // Маппинг для City и CityDto
        CreateMap<City, CityDto>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ReverseMap();

        CreateMap<CityTranslation, CityTranslationDto>().ReverseMap();

        CreateMap<CreateCityDto, City>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<CreateCityTranslationDto, CityTranslation>()
            .ForMember(dest => dest.CityId, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateCityDto, City>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ReverseMap();

        CreateMap<UpdateCityTranslationDto, CityTranslation>()
            .ForMember(dest => dest.CityId, opt => opt.Ignore())
            .ReverseMap();
    }
}
