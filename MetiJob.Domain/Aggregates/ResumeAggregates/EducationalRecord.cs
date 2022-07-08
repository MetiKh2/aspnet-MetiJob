using MetiJob.Domain.Aggregates.Basic;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetiJob.Domain.Aggregates.ResumeAggregates
{
    public class EducationalRecord: BasicAggregate
    {
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string? Major { get; set; }
        public string? CollegeName { get; set; }
        public Grade Grade { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsBusy { get; set; }
        public string? Description { get; set; }

      
    }
}
