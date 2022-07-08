namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdateWorkExperience
    {
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsBusy { get; set; }=false;
        public string? Description { get; set; }
    }
}
