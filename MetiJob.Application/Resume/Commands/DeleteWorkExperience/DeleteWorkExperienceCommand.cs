

using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Resume.Commands.DeleteWorkExperience
{
    public class DeleteWorkExperienceCommand:IRequest<OperationResult<bool>>
    {
        public long Id { get; set; }

        public DeleteWorkExperienceCommand(long id)
        {
            Id = id;
        }
    }
}
