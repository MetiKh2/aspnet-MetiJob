

using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Identity.Queries.GetResetPasswordToken
{
    public class GetResetPasswordTokenQuery:IRequest<OperationResult<string>>
    {
        public string? Email { get; set; }

        public GetResetPasswordTokenQuery(string? email)
        {
            Email = email;
        }

    }
}
