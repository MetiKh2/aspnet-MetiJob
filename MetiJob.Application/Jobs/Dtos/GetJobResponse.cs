
namespace MetiJob.Application.Jobs.Dtos
{
    public class GetJobResponse
    {
        public string Title { get; set; }
        public long CompanyId { get; set; }
        public string? JobCategories { get; set; }
        public string Location { get; set; }
        public int? MinimumWorkExperience { get; set; }
        public string? ContractsCategories { get; set; }
        public long? Salary { get; set; }
        public string? JobDescription { get; set; }
        public string? NeedSkills { get; set; }
        public bool? IsMan { get; set; }
        public long? MinPrice { get; set; }
        public string? MilitaryStatus { get; set; }
        public string? Educational { get; set; }
        public bool IsHot { get; set; } = false;
        public bool IsEnd { get; set; } = false;
        public JobCompanyProperties? JobCompanyProperties { get; set; }

    }
  public  class JobCompanyProperties
    {
        public string? Logo { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? WebSite { get; set; }
        public string? Introduced { get; set; }
    }
}
