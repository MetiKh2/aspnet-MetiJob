using MediatR;

namespace MetiJob.Application.Resume.Commands.UpdateUserAvatar
{
    public class UpdateUserAvatarCommand:IRequest<bool>
    {
        public string AvatarName { get; set; }
        public string UserId { get; set; }

        public UpdateUserAvatarCommand(string avatarName, string userId)
        {
            AvatarName = avatarName;
            UserId = userId;
        }
    }
}
