
using AutoMapper;
using MetiJob.Application.Companies.Dtos;
using MetiJob.Domain.Aggregates.JobsAggregates;

namespace MetiJob.Application.Companies.MappingProfile
{
    public class CompaniesProfile:Profile
    {
        public CompaniesProfile()
        {
            CreateMap<Company,GetCompanyResponse>().ReverseMap();
            CreateMap<Job,CompanyJobs>().ReverseMap();
        }
    }
}
