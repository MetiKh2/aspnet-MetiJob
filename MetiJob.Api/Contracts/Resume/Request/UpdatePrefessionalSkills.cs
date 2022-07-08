using System.ComponentModel.DataAnnotations;

namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdatePrefessionalSkills
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Skills { get; set; }
    }
}
