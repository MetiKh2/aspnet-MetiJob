namespace MetiJob.Application.Jobs.Dtos
{
public class AppliedResponse
    {
        public long Id { get; set; }
        public string? Logo { get; set; }
        public string? Title { get; set; }
        public string? CompanyName { get; set; }
        public string? Status { get; set; }
        public DateTime SendedDate { get; set; }
        public string? Location { get; set; }
        public string ?Contract { get; set; }
    }
}
