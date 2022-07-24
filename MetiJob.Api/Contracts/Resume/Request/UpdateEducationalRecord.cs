using MetiJob.Domain.Enums;

namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdateEducationalRecord
    {
        public long EntityId { get; set; }
        public string? Major { get; set; }
        public string? CollegeName { get; set; }
        public Grade Grade { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }
        public bool? IsBusy { get; set; }=false;
        public string? Description { get; set; }
    }
}
