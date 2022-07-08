
using MediatR;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;

namespace MetiJob.Application.Resume.Commands.UpdateEducationalRecord
{
    public class UpdateEducationalRecordCommand: IRequest<OperationResult<IEnumerable<UpdateEducationalRecordResponse>>>
    {
        public string  UserId { get; set; }
        public List<UpdateEducationalRecordResponse> EducationalRecords { get; set; }
    }
}
