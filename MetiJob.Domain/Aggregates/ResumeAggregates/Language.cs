
using MetiJob.Domain.Aggregates.Basic;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetiJob.Domain.Aggregates.ResumeAggregates
{
    public class Language: BasicAggregate
    {
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Enums.Language? LanguageName{ get; set; }
        public LevelLanguage? LevelLanguage { get; set; }
    }
}
