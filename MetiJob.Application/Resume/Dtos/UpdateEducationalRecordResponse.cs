

using MetiJob.Domain.Enums;

namespace MetiJob.Application.Resume.Dtos
{
    public class UpdateEducationalRecordResponse
    {
        public long EntityId { get; set; }
        public string? Major { get; set; }
        public string? CollegeName { get; set; }
        public Grade Grade { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsBusy { get; set; } = false;
        public string? Description { get; set; }
    }
}
