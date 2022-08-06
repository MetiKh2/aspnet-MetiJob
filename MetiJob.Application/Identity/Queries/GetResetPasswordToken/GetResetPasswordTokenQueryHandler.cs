

using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Identity.Queries.GetResetPasswordToken
{
    public class GetResetPasswordTokenQueryHandler : IRequestHandler<GetResetPasswordTokenQuery, OperationResult<string>>
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public GetResetPasswordTokenQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<OperationResult<string>> Handle(GetResetPasswordTokenQuery request, CancellationToken cancellationToken)
        {
            var result=new OperationResult<string>();
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    result.AddError(ErrorCode.NotFound,"User not found!");
                    return result;
                }
                result.Payload =await  _userManager.GeneratePasswordResetTokenAsync(user);
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
                throw;
            }
            return result;
        }
    }
}
