using MediatR;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Models;
using MetiJob.Application.Paging;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Jobs.Queries.FilterJobs
{
    public class FilterJobsQueryHandler : IRequestHandler<FilterJobsQuery, OperationResult<FilterJobsResponse>>
    {
        private readonly IGenericRepository<Job> _jobRepository;

        public FilterJobsQueryHandler(IGenericRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<OperationResult<FilterJobsResponse>> Handle(FilterJobsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<FilterJobsResponse>();
            try
            {
                var query = _jobRepository.GetQuery().Include(p=>p.Company).OrderByDescending(p => p.CreatedAt).AsQueryable();
                if (request.Dto.IsHot) query = query.Where(p => p.IsHot).AsQueryable();
                if (!string.IsNullOrEmpty(request.Dto.Title)) query = query.Where(p => p.Title.Contains(request.Dto.Title)||p.Company.Name.Contains(request.Dto.Title)).AsQueryable();
                if (!string.IsNullOrEmpty(request.Dto.State)) query = query.Where(p =>p.Location.Contains(request.Dto.State)).AsQueryable();
                if (!string.IsNullOrEmpty(request.Dto.ContractsCategories)) query = query.Where(p => p.ContractsCategories.Contains(request.Dto.ContractsCategories)).AsQueryable();
                if (!string.IsNullOrEmpty(request.Dto.JobCategory)) query = query.Where(p => p.JobCategories.Contains(request.Dto.JobCategory)).AsQueryable();
                if (request.Dto.WorkExperience > -1) query = query.Where(p => p.MinimumWorkExperience >= request.Dto.WorkExperience).AsQueryable();
                if (request.Dto.MinPrice > -1) query = query.Where(p => p.Salary >= request.Dto.MinPrice).AsQueryable();

                var pager = Pager.Build(request.Dto.PageId, await query.CountAsync(), request.Dto.TakeEntity, request.Dto.HowManyShowPageAfterAndBefore);
                var allJobs = await query.Paging(pager).ToListAsync();
                result.Payload = request.Dto.SetJobs(allJobs).SetPaging(pager);
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
