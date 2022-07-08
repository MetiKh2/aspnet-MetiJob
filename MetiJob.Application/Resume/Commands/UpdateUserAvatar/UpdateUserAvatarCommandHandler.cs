

using MediatR;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Resume.Commands.UpdateUserAvatar
{
    public class UpdateUserAvatarCommandHandler : IRequestHandler<UpdateUserAvatarCommand,bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdateUserAvatarCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(UpdateUserAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null) return false;
            user.UpdateImage(request.AvatarName);
            await _userManager.UpdateAsync(user);
            return true;
        }
    }
}
