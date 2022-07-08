using System.ComponentModel.DataAnnotations;

namespace MetiJob.Api.Contracts.Identity
{
    public class RegisterUser
    {
        [MaxLength(200)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(200)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
