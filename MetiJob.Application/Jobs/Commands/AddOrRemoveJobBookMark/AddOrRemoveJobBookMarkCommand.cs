

using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Jobs.Commands.AddOrRemoveJobBookMark
{
    public class AddOrRemoveJobBookMarkCommand:IRequest<OperationResult<bool>>
    {
        public string UserId { get; set; }
        public long JobId { get; set; }

        public AddOrRemoveJobBookMarkCommand(string userId, long jobId)
        {
            UserId = userId;
            JobId = jobId;
        }
    }
}
