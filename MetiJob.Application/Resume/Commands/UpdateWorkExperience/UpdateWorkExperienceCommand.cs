

using MediatR;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;

namespace MetiJob.Application.Resume.Commands.UpdateWorkExperience
{
    public class UpdateWorkExperienceCommand:IRequest<OperationResult<IEnumerable<UpdateWorkExperienceResponse>>>
    {
        public string UserId { get; set; }
        public List<UpdateWorkExperienceResponse> WorkExperiences { get; set; }
    }
}
