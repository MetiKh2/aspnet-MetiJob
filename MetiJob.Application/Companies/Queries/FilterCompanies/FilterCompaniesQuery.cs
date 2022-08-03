
using MediatR;
using MetiJob.Application.Companies.Dtos;
using MetiJob.Application.Models;

namespace MetiJob.Application.Companies.Queries.FilterCompanies
{
    public class FilterCompaniesQuery:IRequest<OperationResult<FilterCompaniesResponse>>
    {
        public FilterCompaniesResponse Filter { get; set; }

        public FilterCompaniesQuery(FilterCompaniesResponse filter)
        {
            Filter = filter;
        }
    }
}
