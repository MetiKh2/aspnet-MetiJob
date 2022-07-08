

using MetiJob.Domain.Enums;

namespace MetiJob.Application.Resume.Dtos
{
    public class UpdateLanguageResponse
    {
        public Domain.Enums.Language? LanguageName { get; set; }
        public LevelLanguage? LevelLanguage { get; set; }
    }
}
