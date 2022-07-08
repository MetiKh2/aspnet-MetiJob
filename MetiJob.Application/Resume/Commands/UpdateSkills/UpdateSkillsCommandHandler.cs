using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Resume.Commands.UpdateSkills
{
    public class UpdateSkillsCommandHandler : IRequestHandler<UpdateSkillsCommand, OperationResult<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdateSkillsCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<OperationResult<string>> Handle(UpdateSkillsCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();
            try
            {
               var skillsArray= request.Skills.Split("/");
                if (skillsArray.Any(p => string.IsNullOrEmpty(p)))
                {
                    result.AddError(ErrorCode.ValidationError,"Skills not valid");
                    return result;
                }
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user is null)
                {
                    result.AddError(ErrorCode.IdentityUserDoesNotExist, "User not found");
                    return result;
                }
                user.ProfessionalSkills= request.Skills;
                await _userManager.UpdateAsync(user);
                result.Payload =request.Skills;
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
