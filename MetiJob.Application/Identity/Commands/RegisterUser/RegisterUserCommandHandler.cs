using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.Identity.Dtos;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Identity.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OperationResult<RegsiterUserResponse>>
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<OperationResult<RegsiterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result=new OperationResult<RegsiterUserResponse>();
            var user = _mapper.Map<ApplicationUser>(request);
            var registerResult= await _userManager.CreateAsync(user, request.Password);
            if (registerResult.Succeeded)
                result.Payload = _mapper.Map<RegsiterUserResponse>(user);
            //Todo Send Email
           else foreach (var item in registerResult.Errors)
                result.AddError(ErrorCode.ServerError,item.Description);
            return result;
        }
    }
}
