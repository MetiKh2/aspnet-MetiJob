using MetiJob.Domain.Aggregates.JobsAggregates;
using MetiJob.Domain.Aggregates.ResumeAggregates;
using MetiJob.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace MetiJob.Domain.Aggregates.IdentityAggregates
{
    public class ApplicationUser : IdentityUser
    {
        #region PersonalInformation
        public string? Image { get;private set; }
        public string? Phone { get; private set; }
        public IranStates? State { get; private set; }
        public string? Address { get; private set; }
        public bool? IsMarried { get; private set; }
        public int? YearOfBirth { get; private set; }
        public bool? IsMan { get; private set; }
        public string? AboutMe { get; private set; }
        public string? JobTitle { get; private set; }
        public bool? HaveJob { get; private set; }
        #endregion
        public string? ProfessionalSkills { get; set; }
        #region CareerJob
        public string? IranStatesCareerJob { get;private set; }
        public string? JobCategories { get; private set; }
        public string? SeniorityLevels { get; private set; }
        public string? ContractsCategories { get; private set; }
        public string? MinPrice { get; private set; }
        public string? JobBenefits { get; private set; }
        #endregion
        public string? ResumeFile { get; set; }
        public bool? IsSeeable { get; set; } = false;
        public string? ResumeAddress { get; set; } = Guid.NewGuid().ToString().Substring(0,10)+new Random().Next(1000000) ;

        public ICollection<EducationalRecord> EducationalRecords { get; set; }
        public ICollection<WorkExperience> WorkExperiences{ get; set; }
        public ICollection<ResumeAggregates.Language> Languages{ get; set; }
        public ICollection<UserJobRequest> UserJobRequests { get; set; }
        public ICollection<UserJobBookMark>  UserJobBookMarks{ get; set; }

        public void UpdatePersonalInfomations(string? phone, IranStates? state, string? address
            , bool? isMarried, int? yearOfBirth, bool? isMan, string? aboutMe,
            string? jobTitle, bool? haveJob)
        {
            Phone = phone;
            State = state;
            Address = address;
            IsMarried = isMarried;
            YearOfBirth = yearOfBirth;
            IsMan = isMan;
            AboutMe = aboutMe;
            JobTitle = jobTitle;
            HaveJob = haveJob;
        }
        public void UpdateCareerJob(string? iranStatesCareerJob, string? jobCategories
            , string? seniorityLevels, string? contractsCategories, string? minPrice, string? jobBenefits)
        {
            IranStatesCareerJob = iranStatesCareerJob;
            JobCategories = jobCategories;
            SeniorityLevels = seniorityLevels;
            ContractsCategories = contractsCategories;
            MinPrice = minPrice;
            JobBenefits = jobBenefits;
        }
        public void UpdateImage(string image)
        {
            Image = image;
        }
        public void UpdateResumeFile(string file)
        {
            ResumeFile=file;
        }
        public void ToggleIsSeeable()
        {
            IsSeeable = !IsSeeable;
        }
    }
    
}
