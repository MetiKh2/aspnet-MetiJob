
using MetiJob.Domain.Aggregates.Basic;

namespace MetiJob.Domain.Aggregates.JobsAggregates
{
    public class Company : BasicAggregate
    {
        public bool IsHot { get; set; }
        public string? Location { get; set; }
        public string? Logo { get; set; }
        public string? Name { get; set; }
        public int Established { get; set; }
        public string? Category { get; set; }
        public double? Rating { get; set; }
        public string? WebSite { get; set; }
        public int? Longitude { get; set; }
        public int? Latitude { get; set; }
        public string? FirstBannerImage { get; set; }
        public string? FirstBannerDescription { get; set; }
        public string? SecondBannerImage { get; set; }
        public string? SecondBannerDescription { get; set; }
        public string? ThirdBannerImage { get; set; }
        public string? ThirdBannerDescription { get; set; }
        public string? FourthBannerImage { get; set; }
        public string? FourthBannerDescription { get; set; }
        public string? FifthBannerImage { get; set; }
        public string? FifthBannerDescription { get; set; }
        public string? Introduced { get; set; }
        public string? WorkCulture { get; set; }
        public string? JobBenefits{ get; set; }
        public string? Worker1_Name { get; set; }
        public string? Worker1_Description { get; set; }
        public string? Worker1_Level { get; set; }
        public string? Worker1_Avatar { get; set; }
        public string? Worker2_Name { get; set; }
        public string? Worker2_Description { get; set; }
        public string? Worker2_Level { get; set; }
        public string? Worker2_Avatar { get; set; }
        public string? Worker3_Name { get; set; }
        public string? Worker3_Description { get; set; }
        public string? Worker3_Level { get; set; }
        public string? Worker3_Avatar { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
