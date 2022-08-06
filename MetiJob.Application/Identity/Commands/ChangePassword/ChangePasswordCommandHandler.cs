

using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Identity.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, OperationResult<string>>
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<OperationResult<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    result.AddError(ErrorCode.NotFound, "User Not found !");
                    return result;
                }
                var token=await _userManager.GeneratePasswordResetTokenAsync(user);
                var password = new Random().Next(1000000, 9999999).ToString();
                var resetPasswordResult = await _userManager.ResetPasswordAsync(user,token, password);
                if (resetPasswordResult.Succeeded)
                    result.Payload = password;
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
