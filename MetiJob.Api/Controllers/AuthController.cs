using MetiJob.Api.Contracts.Identity;
using MetiJob.Api.Filters;
using MetiJob.Application.Identity.Commands.LoginUser;
using MetiJob.Application.Identity.Commands.RegisterUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetiJob.Api.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost]
        [Route(ApiRoutes.Identity.RegisterUser)]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody]RegisterUser registration, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(_mapper.Map<RegisterUserCommand>(registration), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpPost]
        [Route(ApiRoutes.Identity.LoginUser)]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody]LoginUser login, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(_mapper.Map<LoginUserCommand>(login), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
    }
}
