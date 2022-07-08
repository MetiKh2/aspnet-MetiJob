
using MediatR;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Resume.Commands.UpdateIsSeeableResume
{
    public class UpdateIsSeeableResumeCommandHandler : IRequestHandler<UpdateIsSeeableResumeCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdateIsSeeableResumeCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(UpdateIsSeeableResumeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null) return false;
            user.ToggleIsSeeable();
            await _userManager.UpdateAsync(user);
            return true;
        }
    }
}
