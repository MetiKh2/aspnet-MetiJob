using MetiJob.Domain.Aggregates.Basic;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetiJob.Domain.Aggregates.JobsAggregates
{
    public class UserJobRequest:BasicAggregate
    {
        public string UserId { get; set; }
        public long JobId { get; set; }
        public string File { get; set; }
        public string Phone { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User{ get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }
    }
}
