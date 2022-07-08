using System.ComponentModel.DataAnnotations;

namespace MetiJob.Api.Contracts.Resume.Request
{
    public class UpdateWithUserId<T>
    {
        public T Dto { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
