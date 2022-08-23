

using MediatR;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Jobs.Queries.GetBookMarks
{
    public class GetBookMarksQueryHandler : IRequestHandler<GetBookMarksQuery, OperationResult<List<AppliedResponse>>>
    {
        private readonly IGenericRepository<UserJobBookMark> _userBookMarkRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetBookMarksQueryHandler(UserManager<ApplicationUser> userManager, IGenericRepository<UserJobBookMark> userBookMarkRepository)
        {
            _userManager = userManager;
            _userBookMarkRepository = userBookMarkRepository;
        }
        public async Task<OperationResult<List<AppliedResponse>>> Handle(GetBookMarksQuery request, CancellationToken cancellationToken)
        {
        var result = new OperationResult<List<AppliedResponse>>();
        try
        {
            if (await _userManager.FindByIdAsync(request.UserId) == null)
            {
                result.AddError(Enums.ErrorCode.NotFound, "Notfound");
                return result;
            }
                result.Payload = await _userBookMarkRepository.GetQuery().Where(p => p.UserId == request.UserId ).Select(p => new AppliedResponse
                {
                    CompanyName = p.Job.Company.Name,
                    Id = p.JobId,
                    Logo = p.Job.Company.Logo,
                    SendedDate = p.CreatedAt,
                    Title = p.Job.Title,
                    Contract=p.Job.ContractsCategories,
                    Location=p.Job.Location,
                }).ToListAsync();
            }
        catch (Exception e)
        {
            result.AddUnknownError(e.Message);
        }
        return result;
    }
    }
}
