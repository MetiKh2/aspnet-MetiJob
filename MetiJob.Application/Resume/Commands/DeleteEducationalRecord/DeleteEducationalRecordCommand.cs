
using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Resume.Commands.DeleteEducationalRecord
{
    public class DeleteEducationalRecordCommand:IRequest<OperationResult<bool>>
    {
        public long Id { get; set; }

        public DeleteEducationalRecordCommand(long id)
        {
            Id = id;
        }
    }
}
