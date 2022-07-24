using AutoMapper;
using MetiJob.Api.Contracts.Resume.Request;
using MetiJob.Application.Resume.Commands.UpdateCareerJob;
using MetiJob.Application.Resume.Commands.UpdatePersonalInformations;
using MetiJob.Application.Resume.Commands.UpdateSkills;
using MetiJob.Application.Resume.Commands.UpdateWorkExperience;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Application.Resume.Queries.GetResume;

namespace MetiJob.Api.MappingProfile.Resume
{
    public class ResumeProfile:Profile
    {
        public ResumeProfile()
        {
            CreateMap<UpdatePersonalInformationsCommand, UpdatePersonalInformation>().ReverseMap();
            CreateMap<UpdatePrefessionalSkills, UpdateSkillsCommand>().ReverseMap() ;  
            CreateMap<UpdateCareerJobCommand, UpdateCareerJob>().ReverseMap() ;  
            CreateMap<GetResumeQuery, GetResumeItemsRequest>().ReverseMap() ; 
        }
    }
}
