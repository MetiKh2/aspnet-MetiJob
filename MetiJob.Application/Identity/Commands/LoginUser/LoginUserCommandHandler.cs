using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.Identity.Dtos;
using MetiJob.Application.Models;
using MetiJob.Application.Services;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MetiJob.Application.Identity.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, OperationResult<LoginUserResponse>>
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private OperationResult<LoginUserResponse> _result = new();
        private readonly IdentityService _identityService;
        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IdentityService identityService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _identityService = identityService;
        }
        public async Task<OperationResult<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var identityUser = await ValidateAndGetIdentityAsync(request);
                if (_result.IsError) return _result;
                _result.Payload = new LoginUserResponse
                {
                    Email = identityUser.Email,
                    UserName = identityUser.UserName,
                    Token=GetJwtString(identityUser)
                };
            }
            catch (Exception e)
            {
                _result.AddUnknownError(e.Message);
            }
            return _result;
        }
        private async Task<IdentityUser> ValidateAndGetIdentityAsync(LoginUserCommand request)
        {
            var identityUser = await _userManager.FindByNameAsync(request.UserName);

            if (identityUser is null)
            {
                _result.AddError(ErrorCode.IdentityUserDoesNotExist,
                    "User not found");
                return identityUser;
            }

            var validPassword = await _userManager.CheckPasswordAsync(identityUser, request.Password);

            if (!validPassword)
                _result.AddError(ErrorCode.IncorrectPassword, "User not found");

            return identityUser;
        }

        private string GetJwtString(IdentityUser identityUser)
        {
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, identityUser.Email),
            new Claim("IdentityId", identityUser.Id),
            new Claim(JwtRegisteredClaimNames.Name, identityUser.UserName)
            });

            var token = _identityService.CreateSecurityToken(claimsIdentity);
            return _identityService.WriteToken(token);
        }
    }
}
