
using MediatR;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.ResumeAggregates;

namespace MetiJob.Application.Resume.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Language> _languageRepository;

        public DeleteLanguageCommandHandler(IGenericRepository<Language> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            try
            {
                await _languageRepository.DeleteEntity(request.Id);
                await _languageRepository.SaveChangesAsync();
                result.Payload = true;
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
                throw;
            }
            return result;
        }
    }
}
