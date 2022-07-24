
using MetiJob.Domain.Aggregates.Basic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetiJob.Domain.Aggregates.JobsAggregates
{
    public class Job:BasicAggregate
    {
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public string? JobCategories { get; set; }
        public string Location { get; set; }
        public int? MinimumWorkExperience { get; set; }
        public string? ContractsCategories { get; set; }
        public long? Salary { get; set; }
        public string? JobDescription { get; set; }
        public string? NeedSkills { get; set; }
        public bool? IsMan { get; set; }
        public long? MinPrice { get; set; }
        public string? MilitaryStatus { get; set; }
        public string? Educational { get; set; }
        public bool IsHot { get; set; } = false;
        public bool IsEnd { get; set; } = false;
    }
}
