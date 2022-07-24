using MetiJob.Domain.Enums;

namespace MetiJob.Application.Resume.Dtos
{
    public class GetEducationalRecords
    {
        public Guid Id { get; set; }
        public long EntityId { get; set; }
        public string? Major { get; set; }
        public string? CollegeName { get; set; }
        public Grade Grade { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }
        public bool? IsBusy { get; set; }
        public string? Description { get; set; }
    }
}
