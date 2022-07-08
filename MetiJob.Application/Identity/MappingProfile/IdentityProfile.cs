using AutoMapper;
using MetiJob.Application.Identity.Commands.RegisterUser;
using MetiJob.Application.Identity.Dtos;
using MetiJob.Domain.Aggregates.IdentityAggregates;

namespace MetiJob.Application.Identity.MappingProfile
{
    public class IdentityProfile:Profile
    {
        public IdentityProfile()
        {
            CreateMap<ApplicationUser,RegisterUserCommand>().ReverseMap();
            CreateMap<ApplicationUser, RegsiterUserResponse>().ReverseMap();
        }
    }
}
