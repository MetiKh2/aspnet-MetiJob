 

namespace MetiJob.Application.Resume.Dtos
{
    public class GetWorkExperiences
    {
        public string Id { get; set; }
        public long EntityId { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }
        public bool? IsBusy { get; set; }
        public string? Description { get; set; }
    }
}
