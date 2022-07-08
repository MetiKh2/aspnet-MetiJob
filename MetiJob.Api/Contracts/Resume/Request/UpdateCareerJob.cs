using System.ComponentModel.DataAnnotations;

namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdateCareerJob
    {
        public string? IranStatesCareerJob { get; set; }
        public string? JobCategories { get; set; }
        public string? SeniorityLevels { get; set; }
        public string? ContractsCategories { get; set; }
        public string? MinPrice { get; set; }
        public string? JobBenefits { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
