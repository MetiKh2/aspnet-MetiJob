using MetiJob.Api.Contracts.Resume.Request;
using MetiJob.Api.FileUtils;
using MetiJob.Api.Filters;
using MetiJob.Api.ImageUtils;
using MetiJob.Application.Resume.Commands.DeleteEducationalRecord;
using MetiJob.Application.Resume.Commands.DeleteLanguage;
using MetiJob.Application.Resume.Commands.DeleteWorkExperience;
using MetiJob.Application.Resume.Commands.UpdateCareerJob;
using MetiJob.Application.Resume.Commands.UpdateEducationalRecord;
using MetiJob.Application.Resume.Commands.UpdateIsSeeableResume;
using MetiJob.Application.Resume.Commands.UpdateLanguage;
using MetiJob.Application.Resume.Commands.UpdatePersonalInformations;
using MetiJob.Application.Resume.Commands.UpdateSkills;
using MetiJob.Application.Resume.Commands.UpdateUserAvatar;
using MetiJob.Application.Resume.Commands.UpdateUserResumeFile;
using MetiJob.Application.Resume.Commands.UpdateWorkExperience;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Application.Resume.Queries.GetResume;
using Microsoft.AspNetCore.Authorization;

namespace MetiJob.Api.Controllers
{
    [Authorize]
    public class ResumeController : BaseController
    {
        private readonly IWebHostEnvironment _environment;
        public ResumeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost(ApiRoutes.Resume.UpdatePersonalInformation)]
        [ValidateModel]
        public async Task<IActionResult> UpdatePersonalInformation([FromBody] UpdatePersonalInformation request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdatePersonalInformationsCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpPost(ApiRoutes.Resume.UpdateSkills)]
        [ValidateModel]
        public async Task<IActionResult> UpdateSkills([FromBody] UpdatePrefessionalSkills request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateSkillsCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpPost(ApiRoutes.Resume.UpdateWorkExperience)]
        [ValidateModel]
        public async Task<IActionResult> UpdateWorkExperience([FromBody] UpdateWithUserId<List<UpdateWorkExperience>> request, CancellationToken cancellationToken)
        {
            var command = new UpdateWorkExperienceCommand();
            command.UserId = request.UserId;
            command.WorkExperiences = request.Dto.Select(p => new UpdateWorkExperienceResponse
            {
               entityId=p.entityId,
                CompanyName = p.CompanyName,
                Description = p.Description,
                EndDate = p.EndDate != null ? new DateTime(year: p.EndDate.Value, 1, 1) : null,
                IsBusy = p.IsBusy,
                JobTitle = p.JobTitle,
                StartDate = p.StartDate != null ? new DateTime(year: p.StartDate.Value, 1, 1) : null
            }).ToList();
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpPost(ApiRoutes.Resume.UpdateEducationalRecords)]
        [ValidateModel]
        public async Task<IActionResult> UpdateEducationalRecords([FromBody] UpdateWithUserId<List<UpdateEducationalRecord>> request, CancellationToken cancellationToken)
        {
            var command = new UpdateEducationalRecordCommand();
            command.UserId = request.UserId;
            command.EducationalRecords = request.Dto.Select(p => new UpdateEducationalRecordResponse
            {
                EntityId=p.EntityId,
                CollegeName = p.CollegeName,
                Description = p.Description,
                Grade = p.Grade,
                IsBusy = p.IsBusy,
                Major = p.Major,
                EndDate = p.EndDate != null ? new DateTime(year: p.EndDate.Value, 1, 1) : null,
                StartDate = p.StartDate != null ? new DateTime(year: p.StartDate.Value, 1, 1) : null
            }).ToList();
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpPost(ApiRoutes.Resume.UpdateLanguage)]
        [ValidateModel]
        public async Task<IActionResult> UpdateLanguage([FromBody] UpdateWithUserId<List<UpdateLanguage>> request, CancellationToken cancellationToken)
        {
            var command = new UpdateLanguageCommand();
            command.UserId = request.UserId;
            command.Languages = request.Dto.Select(p => new UpdateLanguageResponse
            {
                EntityId=p.EntityId,
                LanguageName = p.LanguageName,
                LevelLanguage = p.LevelLanguage
            }).ToList();
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpPost(ApiRoutes.Resume.UpdateCareerJob)]
        [ValidateModel]
        public async Task<IActionResult> UpdateCareerJob([FromBody] UpdateCareerJob request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateCareerJobCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }

        [HttpPost(ApiRoutes.Resume.UploadUserAvatar)]
        public async Task<IActionResult> UploadUserAvatar(IFormFile avatar, [FromRoute] string userId, CancellationToken cancellationToken)
        {
            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(avatar.FileName);
            if (!avatar.AddImageToServer(fileName, Path.Combine(_environment.ContentRootPath, PathExtension.UserAvatarOriginServer), 300, 200, Path.Combine(_environment.ContentRootPath, PathExtension.UserAvatarThumbServer)))
                return BadRequest();
            var res = await _mediator.Send(new UpdateUserAvatarCommand(fileName, userId));
            if (!res) return BadRequest();
            return Ok(new { imageName = fileName });
        }
        [HttpPost(ApiRoutes.Resume.UploadResume)]
        public async Task<IActionResult> UploadResume(IFormFile resume, [FromRoute] string userId, CancellationToken cancellationToken)
        {
            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(resume.FileName);
            if (!resume.AddPdfToServer(fileName, Path.Combine(_environment.ContentRootPath, PathExtension.UserResumeOriginServer)))
                return BadRequest();
            var res = await _mediator.Send(new UpdateUserResumeFileCommand(fileName, userId));
            if (!res) return BadRequest();
            return Ok(new { imageName = fileName });
        }
        [HttpPost(ApiRoutes.Resume.ToggleIsSeeableResume)]
        public async Task<IActionResult> UploadResume([FromRoute] string userId, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new UpdateIsSeeableResumeCommand(userId));
            if (!res) return NotFound();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetResume([FromQuery] GetResumeItemsRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<GetResumeQuery>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpDelete(ApiRoutes.Resume.DeleteLnaguage)]
        public async Task<IActionResult> DeleteLanguage([FromRoute] long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteLanguageCommand(id), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpDelete(ApiRoutes.Resume.DeleteEducationalRecord)]
        public async Task<IActionResult> DeleteEducationalRecord([FromRoute] long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteEducationalRecordCommand(id), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpDelete(ApiRoutes.Resume.DeleteWorkExperience)]
        public async Task<IActionResult> DeleteWorkExperience([FromRoute] long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteWorkExperienceCommand(id), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }


    }
}
