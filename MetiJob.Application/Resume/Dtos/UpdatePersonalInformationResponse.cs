using MetiJob.Domain.Enums;

namespace MetiJob.Application.Resume.Dtos
{
    public class UpdatePersonalInformationResponse
    {
        public string? Phone { get; set; }
        public string? State { get; set; }
        public string? Address { get; set; }
        public bool? IsMarried { get; set; }
        public int? YearOfBirth { get; set; }
        public bool? IsMan { get; set; }
        public string? AboutMe { get; set; }
        public string? JobTitle { get; set; }
        public bool? HaveJob { get; set; }
    }
}
