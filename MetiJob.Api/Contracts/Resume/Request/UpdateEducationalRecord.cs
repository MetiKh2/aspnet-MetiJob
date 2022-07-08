using MetiJob.Domain.Enums;

namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdateEducationalRecord
    {
        public string? Major { get; set; }
        public string? CollegeName { get; set; }
        public Grade Grade { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsBusy { get; set; }=false;
        public string? Description { get; set; }
    }
}
