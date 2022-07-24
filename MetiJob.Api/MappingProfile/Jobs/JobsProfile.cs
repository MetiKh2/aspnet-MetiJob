using AutoMapper;
using MetiJob.Api.Contracts.Jobs;
using MetiJob.Application.Jobs.Dtos;

namespace MetiJob.Api.MappingProfile.Jobs
{
    public class JobsProfile:Profile
    {
        public JobsProfile()
        {
            CreateMap<FilterJobsRequest, FilterJobsResponse>().ReverseMap();
        }
    }
}
