
using MetiJob.Domain.Aggregates.Basic;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetiJob.Domain.Aggregates.ResumeAggregates
{
    public class WorkExperience: BasicAggregate
    {
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsBusy { get; set; }
        public string? Description { get; set; }
    }
}
