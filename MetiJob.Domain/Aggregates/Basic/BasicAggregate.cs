namespace MetiJob.Domain.Aggregates.Basic
{
    public class BasicAggregate
    {
        public long Id { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastUpdate{ get; set; }
    }
}
