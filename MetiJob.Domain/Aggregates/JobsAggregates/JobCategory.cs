using MetiJob.Domain.Aggregates.Basic;

namespace MetiJob.Domain.Aggregates.JobsAggregates
{
    public class JobCategory:BasicAggregate
    {
        public string Title { get; set; }
    }
}
