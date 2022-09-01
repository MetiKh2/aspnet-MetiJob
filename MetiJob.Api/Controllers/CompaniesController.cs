using MetiJob.Api.Contracts.Companies;
using MetiJob.Application.Companies.Dtos;
using MetiJob.Application.Companies.Queries.FilterCompanies;
using MetiJob.Application.Companies.Queries.GetCompany;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetiJob.Api.Controllers
{
    public class CompaniesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromQuery]FilterCompaniesRequest request ,CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FilterCompaniesQuery(_mapper.Map<FilterCompaniesResponse>(request)), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCompanyQuery(id), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
    }
}
