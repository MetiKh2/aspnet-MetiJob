
using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.ResumeAggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Resume.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, OperationResult<IEnumerable<UpdateLanguageResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<Language> _languageRepository;
        public UpdateLanguageCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager, IGenericRepository<Language> languageRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _languageRepository = languageRepository;
        }
        public async Task<OperationResult<IEnumerable<UpdateLanguageResponse>>> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<UpdateLanguageResponse>>();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user is null)
                {
                    result.AddError(ErrorCode.IdentityUserDoesNotExist, "User not found");
                    return result;
                }
                if (!request.Languages.Any())
                {
                    result.AddError(ErrorCode.ValidationError, "WorkExperiences not found");
                    return result;
                }
                if (await _languageRepository.GetQuery().AnyAsync(p => p.Id == request.Languages[0].EntityId))
                {
                    if (request.Languages.Count == 1)
                    {
                        var language = await _languageRepository.GetEntityById(request.Languages[0].EntityId);
                        language.LevelLanguage = request.Languages[0].LevelLanguage;
                        language.LanguageName= request.Languages[0].LanguageName;
                        language.LastUpdate = DateTime.Now;
                        _languageRepository.EditEntity(language);

                    }
                    else result.AddError(ErrorCode.ValidationError, "educationalRecord not valid");
                }
                else
                    foreach (var work in request.Languages)
                {
                    var newLanguage = _mapper.Map<Language>(work);
                    newLanguage.UserId = request.UserId;
                    await _languageRepository.AddEntity(newLanguage);
                }
                await _languageRepository.SaveChangesAsync();
                result.Payload = request.Languages;

            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
