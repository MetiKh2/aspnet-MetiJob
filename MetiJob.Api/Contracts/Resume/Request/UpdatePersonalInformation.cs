using MetiJob.Domain.Enums;

namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdatePersonalInformation
    {
        #region PersonalInformation
        public string UserId { get; set; }
        public string? Phone { get; set; }
        public IranStates? State { get; set; }
        public string? Address { get; set; }
        public bool? IsMarried { get; set; }
        public int? YearOfBirth { get; set; }
        public bool? IsMan { get; set; }
        public string? AboutMe { get; set; }
        public string? JobTitle { get; set; }
        public bool? HaveJob { get; set; }
        #endregion
    }
}
