

using MetiJob.Domain.Enums;

namespace MetiJob.Application.Resume.Dtos
{
    public class GetLanguages
    {
        public Guid Id { get; set; }
        public long EntityId { get; set; }
        public Language? LanguageName { get; set; }
        public LevelLanguage? LevelLanguage { get; set; }
        public string? LanguageNameString { get; set; }
        public string? LanguageLevelString { get; set; }
    }
}
