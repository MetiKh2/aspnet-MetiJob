
using MediatR;
using MetiJob.Application.Models;

namespace MetiJob.Application.Resume.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand:IRequest<OperationResult<bool>>
    {
        public long Id { get; set; }
        public DeleteLanguageCommand(long id)
        {
            Id = id;
        }
    }
}
