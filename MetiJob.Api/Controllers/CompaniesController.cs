using MetiJob.Api.Contracts.Companies;
using MetiJob.Application.Companies.Dtos;
using MetiJob.Application.Companies.Queries.FilterCompanies;
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
    }
}
