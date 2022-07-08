

using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Application.Resume.Services;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Resume.Commands.UpdateCareerJob
{
    public class UpdateCareerJobCommandHandler : IRequestHandler<UpdateCareerJobCommand, OperationResult<UpdateCareerJobResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdateCareerJobCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<OperationResult<UpdateCareerJobResponse>> Handle(UpdateCareerJobCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UpdateCareerJobResponse>();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user is null)
                {
                    result.AddError(ErrorCode.IdentityUserDoesNotExist, "User not found");
                    return result;
                }
                if (!ArrayServices.CheckSplitNull(request.SeniorityLevels))
                {
                    result.AddError(ErrorCode.ValidationError, "seniorityLevels not valid");
                    return result;
                }
                if (!ArrayServices.CheckSplitNull(request.JobBenefits))
                {
                    result.AddError(ErrorCode.ValidationError, "JobBenefits not valid");
                    return result;
                }
                if (!ArrayServices.CheckSplitNull(request.IranStatesCareerJob))
                {
                    result.AddError(ErrorCode.ValidationError, "IranStatesCareerJob not valid");
                    return result;
                }
                if (!ArrayServices.CheckSplitNull(request.ContractsCategories))
                {
                    result.AddError(ErrorCode.ValidationError, "ContractsCategories not valid");
                    return result;
                }
                user.UpdateCareerJob(request.IranStatesCareerJob,request.JobCategories,request.SeniorityLevels,request.ContractsCategories,request.MinPrice,request.JobBenefits);
               await _userManager.UpdateAsync(user);
                result.Payload = _mapper.Map<UpdateCareerJobResponse>(request) ;
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
