using MetiJob.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetiJob.Domain.Aggregates.ResumeAggregates
{
    public class PersonalInformation
    {
        public string? Image { get; set; }
        public string? Phone { get; set; }
        public IranStates? State { get; set; }
        public string? Address { get; set; }
        public bool? IsMarried { get; set; }
        public int? YearOfBirth { get; set; }
        public bool? IsMan { get; set; }
        public string? AboutMe { get; set; }
        public string? JobTitle { get; set; }
        public bool? HaveJob { get; set; }
    }
}
