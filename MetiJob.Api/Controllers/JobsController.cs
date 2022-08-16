using MetiJob.Api.Contracts.Jobs;
using MetiJob.Api.FileUtils;
using MetiJob.Application.Jobs.Commands.SendResume;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Jobs.Queries.FilterJobs;
using MetiJob.Application.Jobs.Queries.GetJob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetiJob.Api.Controllers
{
    public class JobsController : BaseController
    {
        private readonly IWebHostEnvironment _environment;
        public JobsController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpGet]
        public async Task<IActionResult> FilterJobs([FromQuery]FilterJobsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FilterJobsQuery(_mapper.Map<FilterJobsResponse>(request)), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob([FromRoute]long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetJobQuery(id), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }

        [HttpPost(ApiRoutes.Jobs.SendResume)]
        public async Task<IActionResult> SendResume([FromForm]SendResumeForJobRequest request,[FromForm]IFormFile? file, CancellationToken cancellationToken)
        {
            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file?.FileName);
            if (file != null)
            {
                if (!file.AddPdfToServer(fileName, Path.Combine(_environment.ContentRootPath, PathExtension.UserResumeSendedToJobOriginServer)))
                    return BadRequest();
            }
            else fileName = string.Empty;
            var result = await _mediator.Send(new SendResumeCommand(fileName,request.Phone,request.UserId,request.JobId), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
         
    }
}
