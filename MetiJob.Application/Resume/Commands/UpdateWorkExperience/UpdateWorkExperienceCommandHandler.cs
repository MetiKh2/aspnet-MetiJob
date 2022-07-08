

using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.ResumeAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Resume.Commands.UpdateWorkExperience
{
    public class UpdateWorkExperienceCommandHandler : IRequestHandler<UpdateWorkExperienceCommand, OperationResult<IEnumerable<UpdateWorkExperienceResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<WorkExperience> _workExperineceRepository;
        public UpdateWorkExperienceCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager, IGenericRepository<WorkExperience> workExperineceRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _workExperineceRepository = workExperineceRepository;
        }
        public async Task<OperationResult<IEnumerable<UpdateWorkExperienceResponse>>> Handle(UpdateWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<UpdateWorkExperienceResponse>>();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user is null)
                {
                    result.AddError(ErrorCode.IdentityUserDoesNotExist, "User not found");
                    return result;
                }
                if (!request.WorkExperiences.Any())
                {
                    result.AddError(ErrorCode.ValidationError, "WorkExperiences not found");
                    return result;
                }
                foreach (var work in request.WorkExperiences)
                {
                    var newWorkExperince = _mapper.Map<WorkExperience>(work);
                    newWorkExperince.UserId = request.UserId;
                    await _workExperineceRepository.AddEntity(newWorkExperince);
                }
                await _workExperineceRepository.SaveChangesAsync();
                result.Payload = request.WorkExperiences;

            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
