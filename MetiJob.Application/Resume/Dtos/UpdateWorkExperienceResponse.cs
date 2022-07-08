 
 

namespace MetiJob.Application.Resume.Dtos
{
    public class UpdateWorkExperienceResponse
    {
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsBusy { get; set; } = false;
        public string? Description { get; set; }
    }
}
