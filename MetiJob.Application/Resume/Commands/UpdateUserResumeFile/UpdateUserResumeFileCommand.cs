

using MediatR;

namespace MetiJob.Application.Resume.Commands.UpdateUserResumeFile
{
    public class UpdateUserResumeFileCommand:IRequest<bool>
    {
        public string UserId { get; set; }
        public string FileName { get; set; }

        public UpdateUserResumeFileCommand(string fileName, string userId)
        {
            FileName = fileName;
            UserId = userId;
        }
    }
}
