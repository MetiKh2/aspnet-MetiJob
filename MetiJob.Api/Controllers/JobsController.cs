using MetiJob.Api.Contracts.Jobs;
using MetiJob.Api.FileUtils;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Jobs.Commands.SendResume;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Jobs.Queries.FilterJobs;
using MetiJob.Application.Jobs.Queries.GetApplied;
using MetiJob.Application.Jobs.Queries.GetJob;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MetiJob.Application.Jobs.Commands.AddOrRemoveJobBookMark;
using MetiJob.Application.Jobs.Queries.GetBookMarks;

namespace MetiJob.Api.Controllers
{
    public class JobsController : BaseController
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IGenericRepository<Job> _jobRepository;
        private readonly IGenericRepository<Company> _companyRepository;
        public JobsController(IWebHostEnvironment environment, IGenericRepository<Company> companyRepository, IGenericRepository<Job> jobRepository)
        {
            _environment = environment;
            _companyRepository = companyRepository;
            _jobRepository = jobRepository;
        }
        [HttpGet]
        public async Task<IActionResult> FilterJobs([FromQuery] FilterJobsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FilterJobsQuery(_mapper.Map<FilterJobsResponse>(request)), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob([FromRoute] long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetJobQuery(id), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }

        [HttpPost(ApiRoutes.Jobs.SendResume)]
        public async Task<IActionResult> SendResume([FromForm] SendResumeForJobRequest request, [FromForm] IFormFile? file, CancellationToken cancellationToken)
        {
            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file?.FileName);
            if (file != null)
            {
                if (!file.AddPdfToServer(fileName, Path.Combine(_environment.ContentRootPath, PathExtension.UserResumeSendedToJobOriginServer)))
                    return BadRequest();
            }
            else fileName = string.Empty;
            var result = await _mediator.Send(new SendResumeCommand(fileName, request.Phone, request.UserId, request.JobId), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }

        [HttpGet("job-companies/count")]
        public async Task<IActionResult> GetJobsAndCompaniesCount()
        {
            var companiesCount = await _companyRepository.GetQuery().CountAsync();
            var jobsCount = await _jobRepository.GetQuery().CountAsync();
            return Ok(new
            {
                companiesCount = companiesCount,
                jobsCount = jobsCount
            });
        }
        [Authorize]
        [HttpGet("applied/{userId}")]
        public async Task<IActionResult> Applied([FromRoute] string userId, [FromQuery] string? type, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAppliedQuery(type, userId), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [Authorize]
        [HttpPost("bookmark/{userId}/{jobId}")]
        public async Task<IActionResult> BookMark([FromRoute] string userId, [FromRoute] long jobId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new AddOrRemoveJobBookMarkCommand(userId, jobId), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [Authorize]
        [HttpGet("bookmarks/{userId}")]
        public async Task<IActionResult> GetBookMarks([FromRoute] string userId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBookMarksQuery(userId), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
    }
}
