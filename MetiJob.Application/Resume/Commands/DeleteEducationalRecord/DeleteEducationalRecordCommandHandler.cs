

using MediatR;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.ResumeAggregates;

namespace MetiJob.Application.Resume.Commands.DeleteEducationalRecord
{
    public class DeleteEducationalRecordCommandHandler : IRequestHandler<DeleteEducationalRecordCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<EducationalRecord> _educationalRecordsRepository;

        public DeleteEducationalRecordCommandHandler(IGenericRepository<EducationalRecord> educationalRecordsRepository)
        {
            _educationalRecordsRepository = educationalRecordsRepository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteEducationalRecordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            try
            {
                await _educationalRecordsRepository.DeleteEntity(request.Id);
                await _educationalRecordsRepository.SaveChangesAsync();
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
