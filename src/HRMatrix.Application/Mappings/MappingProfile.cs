﻿using AutoMapper;
using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.MaterialStatus;
using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.UserProfile;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Application.DTOs.WorkExperiences;
using HRMatrix.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Маппинг для создания UserProfile
        CreateMap<CreateUserProfileDto, UserProfile>()
            .ForMember(dest => dest.UserEducations, opt => opt.Ignore())
            .ForMember(dest => dest.FamilyStatus, opt => opt.MapFrom(src => src.FamilyStatus))
            .ForMember(dest => dest.UserProfileSkills, opt => opt.MapFrom(src => src.UserProfileSkills))
            .ForMember(dest => dest.WorkExperiences, opt => opt.MapFrom(src => src.WorkExperiences));

        // Маппинг для обновления UserProfile
        CreateMap<UpdateUserProfileDto, UserProfile>()
            .ForMember(dest => dest.UserEducations, opt => opt.Ignore())
            .ForMember(dest => dest.FamilyStatus, opt => opt.MapFrom(src => src.FamilyStatus))
            .ForMember(dest => dest.UserProfileSkills, opt => opt.MapFrom(src => src.UserProfileSkills))
            .ForMember(dest => dest.WorkExperiences, opt => opt.MapFrom(src => src.WorkExperiences))
            .ReverseMap();

        // Маппинг для UserProfile и FamilyStatus
        CreateMap<UserProfile, UserProfileDto>()
            .ForMember(dest => dest.FamilyStatus, opt => opt.MapFrom(src => src.FamilyStatus))
            .ForMember(dest => dest.WorkExperiences, opt => opt.MapFrom(src => src.WorkExperiences))
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
    }
}