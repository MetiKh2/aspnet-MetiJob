using AutoMapper;
using MetiJob.Api.Contracts.Companies;
using MetiJob.Api.Contracts.Jobs;
using MetiJob.Application.Companies.Dtos;

namespace MetiJob.Api.MappingProfile.Companies
{
    public class CompaniesProfile:Profile
    {
        public CompaniesProfile()
        {
            CreateMap<FilterCompaniesResponse, FilterCompaniesRequest>().ReverseMap();
        }
    }
}
