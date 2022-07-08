using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Resume.Commands.UpdateSkills
{
    public class UpdateSkillsCommand:IRequest<OperationResult<string>>
    {
        public string Skills { get; set; }
        public string UserId { get; set; }
    }
}
