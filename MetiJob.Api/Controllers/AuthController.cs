using MetiJob.Api.Contracts.Identity;
using MetiJob.Api.Filters;
using MetiJob.Application.Identity.Commands.ChangePassword;
using MetiJob.Application.Identity.Commands.LoginUser;
using MetiJob.Application.Identity.Commands.RegisterUser;
using MetiJob.Application.Identity.Commands.ResetPassword;
using MetiJob.Application.Identity.Queries.GetResetPasswordToken;
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
        //not use
        [HttpGet]
        [Route(ApiRoutes.Identity.ForgotPassword)]
        [ValidateModel]
        public async Task<IActionResult> ForgotPassword(string email, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetResetPasswordTokenQuery(email));
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        //not use
        [HttpPost]
        [Route(ApiRoutes.Identity.ResetPassword)]
        [ValidateModel]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ResetPasswordCommand(request.Email) { Password=request.Password,RePassword=request.RePassword,Token=request.Token});
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }
        [HttpPost]
        [Route(ApiRoutes.Identity.ChangePassword)]
        [ValidateModel]
        public async Task<IActionResult> ChangePassword(string email, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ChangePasswordCommand(email));
            if (result.IsError) return HandleErrorResponse(result.Errors);
            //send email for password
            return Ok(new { pass=result.Payload });
        }

    }
}
