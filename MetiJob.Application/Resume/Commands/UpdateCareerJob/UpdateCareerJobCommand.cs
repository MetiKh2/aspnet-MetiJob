

using MediatR;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;

namespace MetiJob.Application.Resume.Commands.UpdateCareerJob
{
    public class UpdateCareerJobCommand:IRequest<OperationResult<UpdateCareerJobResponse>>
    {
        public string? IranStatesCareerJob { get; set; }
        public string? JobCategories { get; set; }
        public string? SeniorityLevels { get; set; }
        public string? ContractsCategories { get; set; }
        public string? MinPrice { get; set; }
        public string? JobBenefits { get; set; }
        public string UserId { get; set; }
    }
}
