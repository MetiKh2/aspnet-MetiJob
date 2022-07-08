

using MediatR;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Resume.Commands.UpdateUserResumeFile
{
    public class UpdateUserResumeFileCommandHandler : IRequestHandler<UpdateUserResumeFileCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdateUserResumeFileCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
       
        public async Task<bool> Handle(UpdateUserResumeFileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null) return false;
            user.UpdateResumeFile(request.FileName);
            await _userManager.UpdateAsync(user);
            return true;
        }
    }
}
