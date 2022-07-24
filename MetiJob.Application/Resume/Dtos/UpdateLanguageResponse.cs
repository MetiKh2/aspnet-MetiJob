

using MetiJob.Domain.Enums;

namespace MetiJob.Application.Resume.Dtos
{
    public class UpdateLanguageResponse
    {
        public long EntityId { get; set; }
        public Domain.Enums.Language? LanguageName { get; set; }
        public LevelLanguage? LevelLanguage { get; set; }
    }
}
