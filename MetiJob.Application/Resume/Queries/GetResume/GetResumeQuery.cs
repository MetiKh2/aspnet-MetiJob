

using MediatR;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Domain.Aggregates.IdentityAggregates;

namespace MetiJob.Application.Resume.Queries.GetResume
{
    public class GetResumeQuery:IRequest<OperationResult<GetResumeResponse>>
    {
        public string UserId { get; set; }
        public bool Image { get; set; }
        public bool PersonalInformations { get; set; }
        public bool WorkExperience { get; set; }
        public bool EducationalRecords { get; set; }
        public bool ProfessionalSkills { get; set; }
        public bool Languages { get; set; }
        public bool CareerJob { get; set; }
    }
}
