
using MetiJob.Domain.Aggregates.JobsAggregates;
using MetiJob.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetiJob.Domain.Aggregates.ResumeAggregates
{
    public class CareerJob
    {
        public List<IranStates>? IranStates{ get; set; }
        public List<string>? JobCategories{ get; set; }
        public List<SeniorityLevel>? SeniorityLevels { get; set; }
        public List<ContractCategories>? ContractsCategories { get; set; }
        public string? MinPrice { get; set; }
        public List<JobBenefits>? JobBenefits { get; set; }
    }
}
