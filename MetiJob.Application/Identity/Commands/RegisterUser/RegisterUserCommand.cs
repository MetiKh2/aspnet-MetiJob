using MediatR;
using MetiJob.Application.Identity.Dtos;
using MetiJob.Application.Models;

namespace MetiJob.Application.Identity.Commands.RegisterUser
{
    public class RegisterUserCommand:IRequest<OperationResult<RegsiterUserResponse>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
