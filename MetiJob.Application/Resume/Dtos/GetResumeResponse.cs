

using MetiJob.Domain.Aggregates.ResumeAggregates;
using MetiJob.Domain.Enums;

namespace MetiJob.Application.Resume.Dtos
{
    public class GetResumeResponse
    {
        #region PersonalInformation
public string? Email{ get;  set; }
        public string? Image { get;  set; }
        public string? Phone { get;  set; }
        public IranStates? State { get;  set; }
        public string? Address { get;  set; }
        public bool? IsMarried { get;  set; }
        public int? YearOfBirth { get;  set; }
        public bool? IsMan { get;  set; }
        public string? AboutMe { get;  set; }
        public string? JobTitle { get;  set; }
        public bool? HaveJob { get;  set; }
        #endregion
        public string? ProfessionalSkills { get; set; }
        #region CareerJob
        public string? IranStatesCareerJob { get;  set; }
        public string? JobCategories { get;  set; }
        public string? SeniorityLevels { get;  set; }
        public string? ContractsCategories { get;  set; }
        public string? MinPrice { get;  set; }
        public string? JobBenefits { get;  set; }
        #endregion
        public string? ResumeFile { get; set; }
        public bool? IsSeeable { get; set; } 
        public string? ResumeAddress { get; set; }  

        public List<GetEducationalRecords>? EducationalRecords { get; set; }
        public List<GetWorkExperiences>? WorkExperiences { get; set; }
        public List<GetLanguages>?Languages { get; set; }
    }
}
