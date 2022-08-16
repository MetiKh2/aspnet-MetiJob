namespace MetiJob.Api.Contracts.Jobs
{
    public class SendResumeForJobRequest
    {
        public string UserId { get; set; }
        public long JobId { get; set; }
        //public IFormFile File { get; set; }
        public string Phone { get; set; }
    }
}
