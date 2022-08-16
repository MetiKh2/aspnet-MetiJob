

using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Jobs.Commands.SendResume
{
    public class SendResumeCommand:IRequest<OperationResult<bool>>
    {
        public long JobId { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public string File { get; set; }

        public SendResumeCommand(string file, string phone, string userId, long jobId)
        {
            File = file;
            Phone = phone;
            UserId = userId;
            JobId = jobId;
        }
    }
}
