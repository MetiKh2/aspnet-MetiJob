

using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Identity.Commands.ChangePassword
{
    public class ChangePasswordCommand:IRequest<OperationResult<string>>
    {
        public string Email { get; set; }

        public ChangePasswordCommand(string email)
        {
            Email = email;
        }
    }
}
