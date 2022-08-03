using MediatR;
using MetiJob.Application.Companies.Dtos;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Application.Paging;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Companies.Queries.FilterCompanies
{
    public class FilterCompaniesQueryHandler : IRequestHandler<FilterCompaniesQuery, OperationResult<FilterCompaniesResponse>>
    {
        private readonly IGenericRepository<Company> _companiesRepository;

        public FilterCompaniesQueryHandler(IGenericRepository<Company> companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<OperationResult<FilterCompaniesResponse>> Handle(FilterCompaniesQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<FilterCompaniesResponse>();
            try
            {
                var query = _companiesRepository.GetQuery().OrderByDescending(p => p.CreatedAt).AsQueryable();
                if (!string.IsNullOrEmpty(request.Filter.Name)) query = query.Where(p => p.Name.Contains(request.Filter.Name)).AsQueryable();
                if (!string.IsNullOrEmpty(request.Filter.Location)) query = query.Where(p => p.Location.Contains(request.Filter.Location)).AsQueryable();
                switch (request.Filter.OrderBy)
                {
                    case "top":
                        {
                           query= query.OrderByDescending(p => p.Rating).AsQueryable();
                            break;
                        }
                    default: { break; }
                }

                var pager = Pager.Build(request.Filter.PageId, await query.CountAsync(), request.Filter.TakeEntity, request.Filter.HowManyShowPageAfterAndBefore);
                var allCompanies = await query.Paging(pager).ToListAsync();
                result.Payload = request.Filter.SetCompanies(allCompanies).SetPaging(pager);
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
