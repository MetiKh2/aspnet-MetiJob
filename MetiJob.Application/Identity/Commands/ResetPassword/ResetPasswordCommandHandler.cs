

using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Identity.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, OperationResult<bool>>
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<OperationResult<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if(user==null)
                {
                    result.AddError(ErrorCode.NotFound,"User Not found !");
                    return result;
                }
                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
                if (resetPasswordResult.Succeeded)
                    result.Payload = true;
                else
                    foreach (var item in resetPasswordResult.Errors)
                        result.AddError(ErrorCode.ValidationError, item.Description);
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }

            return result;
        }
    }
}
