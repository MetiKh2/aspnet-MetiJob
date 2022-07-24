


using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.Models;
using MetiJob.Application.Resume.Dtos;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Resume.Queries.GetResume
{
    public class GetResumeQueryHandler : IRequestHandler<GetResumeQuery, OperationResult<GetResumeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IGenericRepository<EducationalRecord> _educationalRecordRepository;
        public GetResumeQueryHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<OperationResult<GetResumeResponse>> Handle(GetResumeQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetResumeResponse>();
            try
            {
                var payload = new GetResumeResponse();
                var user = await _userManager.Users.Include(p => p.WorkExperiences).Include(p => p.EducationalRecords).Include(p => p.Languages).FirstOrDefaultAsync(p => p.Id == request.UserId);
                if (user == null)
                {
                    result.AddError(ErrorCode.IdentityUserDoesNotExist, "User not found");
                    return result;
                }
                if (request.Image)
                    payload.Image = user.Image;
                if (request.Languages)
                    payload.Languages = user.Languages.Select(p => new GetLanguages
                    {
                        LanguageName = p.LanguageName,
                        LevelLanguage = p.LevelLanguage,
                        EntityId = p.Id,
                        Id = Guid.NewGuid(),
                        LanguageLevelString=p.LevelLanguage.ToString(),
                        LanguageNameString=p.LanguageName.ToString(),
                    }).ToList();
                if (request.WorkExperience)
                    payload.WorkExperiences = user.WorkExperiences.Select(p => new GetWorkExperiences
                    {
                        Id = Guid.NewGuid().ToString(),
                        EntityId = p.Id,
                        CompanyName = p.CompanyName,
                        Description = p.Description,
                        EndDate = p.EndDate != null ? p.EndDate.Value.Year : null,
                        IsBusy = p.IsBusy,
                        JobTitle = p.JobTitle,
                        StartDate = p.StartDate != null ? p.StartDate.Value.Year : null
                    }).ToList();
                if (request.PersonalInformations)
                {
                    payload.Image = user.Image;
                    payload.Phone = user.Phone;
                    payload.State = user.State;
                    payload.Address = user.Address;
                    payload.IsMarried = user.IsMarried;
                    payload.YearOfBirth = user.YearOfBirth;
                    payload.JobTitle = user.JobTitle;
                    payload.IsMan = user.IsMan;
                    payload.HaveJob = user.HaveJob;
                    payload.Email = user.Email;
                    payload.AboutMe = user.AboutMe;
                }
                if (request.CareerJob)
                {
                    payload.IranStatesCareerJob = user.IranStatesCareerJob;
                    payload.JobCategories = user.JobCategories;
                    payload.State = user.State;
                    payload.SeniorityLevels = user.SeniorityLevels;
                    payload.ContractsCategories = user.ContractsCategories;
                    payload.MinPrice = user.MinPrice;
                    payload.JobBenefits = user.JobBenefits;
                }
                if (request.EducationalRecords)
                    payload.EducationalRecords = user.EducationalRecords.Select(p => new GetEducationalRecords
                    {
                        Id = Guid.NewGuid(),
                        EntityId = p.Id,
                        CollegeName = p.CollegeName,
                        Description = p.Description,
                        Major = p.Major,
                        Grade = p.Grade,
                        EndDate = p.EndDate != null ? p.EndDate.Value.Year : null,
                        IsBusy = p.IsBusy,
                        StartDate = p.StartDate != null ? p.StartDate.Value.Year : null
                    }).ToList();
                if (request.ProfessionalSkills) payload.ProfessionalSkills = user.ProfessionalSkills;
                result.Payload = payload;
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
