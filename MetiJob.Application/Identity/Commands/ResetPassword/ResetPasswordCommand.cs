

using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Identity.Commands.ResetPassword
{
    public class ResetPasswordCommand:IRequest<OperationResult<bool>>
    {
        public string Email { get; set; }

        public ResetPasswordCommand(string email)
        {
            Email= email;
        }
        public string Token { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }

    }
}
