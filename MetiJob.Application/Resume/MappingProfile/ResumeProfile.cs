using AutoMapper;
using MetiJob.Application.Resume.Commands.UpdateCareerJob;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.ResumeAggregates;

namespace MetiJob.Application.Resume.MappingProfile
{
    public class ResumeProfile:Profile
    {
        public ResumeProfile()
        {
            CreateMap<UpdatePersonalInformationResponse,ApplicationUser>().ReverseMap();
            CreateMap<UpdateWorkExperienceResponse, WorkExperience>().ReverseMap();
            CreateMap<UpdateEducationalRecordResponse, EducationalRecord>().ReverseMap();
            CreateMap<UpdateLanguageResponse, Language>().ReverseMap();
            CreateMap<UpdateCareerJobResponse, UpdateCareerJobCommand>().ReverseMap();

        }
    }
}
