using MetiJob.Api.Contracts.Jobs;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Jobs.Queries.FilterJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetiJob.Api.Controllers
{
    public class JobsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> FilterJobs([FromQuery]FilterJobsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FilterJobsQuery(_mapper.Map<FilterJobsResponse>(request)), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
    }
}
