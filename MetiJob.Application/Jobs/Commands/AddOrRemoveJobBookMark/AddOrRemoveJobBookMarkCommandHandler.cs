

using MediatR;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Jobs.Commands.AddOrRemoveJobBookMark
{
    public class AddOrRemoveJobBookMarkCommandHandler : IRequestHandler<AddOrRemoveJobBookMarkCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<UserJobBookMark> _userBookMarkRepository;
        private readonly IGenericRepository<Job> _jobRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddOrRemoveJobBookMarkCommandHandler(IGenericRepository<UserJobBookMark> userBookMarkRepository, UserManager<ApplicationUser> userManager, IGenericRepository<Job> jobRepository)
        {
            _userBookMarkRepository = userBookMarkRepository;
            _userManager = userManager;
            _jobRepository = jobRepository;
        }

        public async Task<OperationResult<bool>> Handle(AddOrRemoveJobBookMarkCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            try
            {
                if (await _userManager.FindByIdAsync(request.UserId) == null || !await _jobRepository.IsExist(request.JobId))
                {
                    result.AddError(Enums.ErrorCode.NotFound, "Notfound");
                    return result;
                }
                if (!await _userBookMarkRepository.GetQuery().Where(p=>p.UserId==request.UserId&&p.JobId==request.JobId).AnyAsync())
                    await _userBookMarkRepository.AddEntity(new UserJobBookMark { JobId = request.JobId, UserId = request.UserId });
                else
                {
                    var ids =await _userBookMarkRepository.GetQuery().Where(p=>p.UserId==request.UserId&&p.JobId==request.JobId).ToListAsync();
                    foreach (var item in ids)
                        _userBookMarkRepository.DeleteEntity(item);
                }
                await _userBookMarkRepository.SaveChangesAsync();
                result.Payload = true;
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
