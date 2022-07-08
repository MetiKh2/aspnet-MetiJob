
using MediatR;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;

namespace MetiJob.Application.Resume.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand:IRequest<OperationResult<IEnumerable<UpdateLanguageResponse>>>
    {
        public string UserId { get; set; }
        public List<UpdateLanguageResponse> Languages { get; set; }
    }
}
