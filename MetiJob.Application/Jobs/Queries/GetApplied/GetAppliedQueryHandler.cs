

using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Jobs.Queries.GetApplied
{
    public class GetAppliedQueryHandler : IRequestHandler<GetAppliedQuery, OperationResult<List<AppliedResponse>>>
    {
        private readonly IGenericRepository<Job> _jobRepository;
        private readonly IGenericRepository<UserJobRequest> _userJobRequestRepository;
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public GetAppliedQueryHandler(IGenericRepository<Job> jobRepository, IMapper mapper, UserManager<ApplicationUser> userManager, IGenericRepository<UserJobRequest> userJobRequestRepository)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _userManager = userManager;
            _userJobRequestRepository = userJobRequestRepository;
        }
        public async Task<OperationResult<List<AppliedResponse>>> Handle(GetAppliedQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<AppliedResponse>>();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    result.AddError(ErrorCode.NotFound, "User Not found");
                    return result;
                }
                 
                result.Payload = await _userJobRequestRepository.GetQuery().Where(p => p.UserId == request.UserId&&(!string.IsNullOrEmpty(request.Type)&&request.Type!="All"?p.Status==request.Type:p.Status!="")).Select(p => new AppliedResponse
                {
                    CompanyName=p.Job.Company.Name,
                    Id=p.JobId,
                    Logo=p.Job.Company.Logo,
                    SendedDate=p.CreatedAt,
                    Status=p.Status,
                    Title=p.Job.Title
                }).ToListAsync();
                
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
