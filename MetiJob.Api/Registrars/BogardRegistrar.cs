using MediatR;
using MetiJob.Api.MappingProfile.Resume;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Identity.Commands.RegisterUser;
using MetiJob.Application.Services;

namespace MetiJob.Api.Registrars
{
    public class BogardRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program), typeof(RegisterUserCommand)); 
            builder.Services.AddMediatR(typeof(RegisterUserCommand));
            builder.Services.AddScoped<IdentityService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
