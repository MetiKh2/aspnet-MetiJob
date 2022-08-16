

using AutoMapper;
using MetiJob.Application.Jobs.Commands.SendResume;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Domain.Aggregates.JobsAggregates;

namespace MetiJob.Application.Jobs.MappingProfile
{
    public class JobsProfile:Profile
    {
        public JobsProfile()
        {
            CreateMap<GetJobResponse,Domain.Aggregates.JobsAggregates.Job>().ReverseMap();
            CreateMap<JobCompanyProperties, Domain.Aggregates.JobsAggregates.Company>().ReverseMap();
            CreateMap<UserJobRequest,SendResumeCommand>().ReverseMap();
        }
    }
}
