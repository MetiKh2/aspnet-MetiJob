

using MediatR;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Models;

namespace MetiJob.Application.Jobs.Queries.FilterJobs
{
    public class FilterJobsQuery:IRequest<OperationResult<FilterJobsResponse>>
    {
        public FilterJobsResponse Dto { get; set; }
        public FilterJobsQuery(FilterJobsResponse dto)
        {
            Dto = dto;
        }
    }
}
