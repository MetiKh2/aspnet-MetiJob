

using MediatR;

namespace MetiJob.Application.Resume.Commands.UpdateIsSeeableResume
{
    public class UpdateIsSeeableResumeCommand:IRequest<bool>
    {
        public string UserId { get; set; }

        public UpdateIsSeeableResumeCommand(string userId)
        {
            UserId = userId;
        }
    }
}
