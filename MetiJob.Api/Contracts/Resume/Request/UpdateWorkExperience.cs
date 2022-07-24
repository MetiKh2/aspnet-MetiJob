namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdateWorkExperience
    {
        public long entityId { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }
        public bool? IsBusy { get; set; }=false;
        public string? Description { get; set; }
    }
}
