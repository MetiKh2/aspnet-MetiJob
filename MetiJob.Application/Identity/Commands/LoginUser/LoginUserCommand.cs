using MediatR;
using MetiJob.Application.Identity.Dtos;
using MetiJob.Application.Models;

namespace MetiJob.Application.Identity.Commands.LoginUser
{
    public class LoginUserCommand:IRequest<OperationResult<LoginUserResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
