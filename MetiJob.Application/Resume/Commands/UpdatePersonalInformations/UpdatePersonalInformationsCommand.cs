

using MediatR;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Domain.Enums;

namespace MetiJob.Application.Resume.Commands.UpdatePersonalInformations
{
    public class UpdatePersonalInformationsCommand:IRequest<OperationResult<UpdatePersonalInformationResponse>>
    {
        public string UserId { get; set; }
        public string? Phone { get; set; }
        public IranStates? State { get; set; }
        public string? Address { get; set; }
        public bool? IsMarried { get; set; }
        public int? YearOfBirth { get; set; }
        public bool? IsMan { get; set; }
        public string? AboutMe { get; set; }
        public string? JobTitle { get; set; }
        public bool? HaveJob { get; set; }
    }
}
