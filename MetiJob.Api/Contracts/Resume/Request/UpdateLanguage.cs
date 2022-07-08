using MetiJob.Domain.Enums;

namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdateLanguage
    {
        public Domain.Enums.Language? LanguageName { get; set; }
        public LevelLanguage? LevelLanguage { get; set; }
    }
}
