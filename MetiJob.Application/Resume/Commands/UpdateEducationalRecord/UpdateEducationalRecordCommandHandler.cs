using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.ResumeAggregates;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Application.Resume.Commands.UpdateEducationalRecord
{
    public class UpdateEducationalRecordCommandHandler : IRequestHandler<UpdateEducationalRecordCommand, OperationResult<IEnumerable<UpdateEducationalRecordResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<EducationalRecord> _educationalRecordRepository;
        public UpdateEducationalRecordCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager, IGenericRepository<EducationalRecord> educationalRecordRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _educationalRecordRepository = educationalRecordRepository;
        }
        public async Task<OperationResult<IEnumerable<UpdateEducationalRecordResponse>>> Handle(UpdateEducationalRecordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<UpdateEducationalRecordResponse>>();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user is null)
                {
                    result.AddError(ErrorCode.IdentityUserDoesNotExist, "User not found");
                    return result;
                }
                if (!request.EducationalRecords.Any())
                {
                    result.AddError(ErrorCode.ValidationError, "EducationalRecords not found");
                    return result;
                }
                foreach (var work in request.EducationalRecords)
                {
                    var newEducationalRecord = _mapper.Map<EducationalRecord>(work);
                    newEducationalRecord.UserId = request.UserId;
                    await _educationalRecordRepository.AddEntity(newEducationalRecord);
                }
                await _educationalRecordRepository.SaveChangesAsync();
                result.Payload = request.EducationalRecords;

            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
