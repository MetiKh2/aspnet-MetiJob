

using MediatR;
using MetiJob.Application.Companies.Dtos;
using MetiJob.Application.Models;

namespace MetiJob.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQuery:IRequest<OperationResult<GetCompanyResponse>>
    {
        public long Id { get; set; }

        public GetCompanyQuery(long id)
        {
            Id = id;
        }
    }
}
