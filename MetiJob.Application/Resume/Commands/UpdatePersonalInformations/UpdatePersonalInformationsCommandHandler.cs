
using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Resume.Commands.UpdatePersonalInformations
{
    public class UpdatePersonalInformationsCommandHandler : IRequestHandler<UpdatePersonalInformationsCommand, OperationResult<UpdatePersonalInformationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdatePersonalInformationsCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<OperationResult<UpdatePersonalInformationResponse>> Handle(UpdatePersonalInformationsCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UpdatePersonalInformationResponse>();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user is null)
                {
                    result.AddError(ErrorCode.IdentityUserDoesNotExist, "User not found");
                    return result;
                }
                user.UpdatePersonalInfomations(request.Phone, request.State, request.Address, request.IsMarried, request.YearOfBirth, request.IsMan
                    , request.AboutMe, request.JobTitle, request.HaveJob);
                await _userManager.UpdateAsync(user);
                result.Payload = _mapper.Map<UpdatePersonalInformationResponse>(user);
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
