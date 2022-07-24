

using MediatR;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.ResumeAggregates;

namespace MetiJob.Application.Resume.Commands.DeleteWorkExperience
{
    public class DeleteWorkExperienceCommandHandler : IRequestHandler<DeleteWorkExperienceCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<WorkExperience> _workExperiencesRepository;

        public DeleteWorkExperienceCommandHandler(IGenericRepository<WorkExperience> workExperiencesRepository)
        {
            _workExperiencesRepository = workExperiencesRepository;
        }
        public async Task<OperationResult<bool>> Handle(DeleteWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            try
            {
                await _workExperiencesRepository.DeleteEntity(request.Id);
                await _workExperiencesRepository.SaveChangesAsync();
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
