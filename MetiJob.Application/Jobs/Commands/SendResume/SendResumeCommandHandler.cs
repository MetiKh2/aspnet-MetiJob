

using AutoMapper;
using MediatR;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Jobs.Commands.SendResume
{
    public class SendResumeCommandHandler : IRequestHandler<SendResumeCommand, OperationResult<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<UserJobRequest> _userJobRequestRepository;
        private readonly IGenericRepository<Job> _jobRepository;
        private readonly IMapper _mapper;

        public SendResumeCommandHandler(UserManager<ApplicationUser> userManager, IGenericRepository<UserJobRequest> userJobRequestRepository, IGenericRepository<Job> jobRepository, IMapper mapper)
        {
            _userManager = userManager;
            _userJobRequestRepository = userJobRequestRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<bool>> Handle(SendResumeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            try
            {
                if(await _userManager.FindByIdAsync(request.UserId)==null||!await _jobRepository.IsExist(request.JobId))
                {
                    result.AddError(Enums.ErrorCode.NotFound,"Notfound");
                    return result;
                }
                await _userJobRequestRepository.AddEntity(_mapper.Map<UserJobRequest>(request)) ;
                await _userJobRequestRepository.SaveChangesAsync();
                result.Payload = true;
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
