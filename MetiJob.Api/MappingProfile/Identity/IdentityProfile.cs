using AutoMapper;
using MetiJob.Api.Contracts.Identity;
using MetiJob.Application.Identity.Commands.LoginUser;
using MetiJob.Application.Identity.Commands.RegisterUser;

namespace MetiJob.Api.MappingProfile.Identity
{
    public class IdentityProfile:Profile
    {
        public IdentityProfile()
        {
            CreateMap<RegisterUserCommand,RegisterUser>().ReverseMap();
            CreateMap<LoginUserCommand,LoginUser>().ReverseMap();
        }
    }
}
