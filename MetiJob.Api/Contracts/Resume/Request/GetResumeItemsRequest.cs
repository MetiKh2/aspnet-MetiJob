using System.ComponentModel.DataAnnotations;

namespace MetiJob.Api.Contracts.Resume.Request
{
    public class GetResumeItemsRequest
    {
        [Required]
        public string UserId { get; set; }
        public bool Image { get; set; }
        public bool PersonalInformations { get; set; }
        public bool WorkExperience { get; set; }
        public bool EducationalRecords { get; set; }
        public bool ProfessionalSkills { get; set; }
        public bool Languages { get; set; }
        public bool CareerJob { get; set; }
    }
}
