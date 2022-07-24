

using MetiJob.Application.Paging;

namespace MetiJob.Application.Jobs.Dtos
{
    public class FilterJobsResponse:BasePaging
    {
        public string? Title { get; set; }
        public string? CompanyName { get; set; }
        public string? State { get; set; }
        public string? ContractsCategories { get; set; }
        public string? JobCategory { get; set; }
        public int? WorkExperience { get; set; }
        public long? MinPrice { get; set; }
        public bool IsHot { get; set; }
        public List<Domain.Aggregates.JobsAggregates.Job> Jobs { get; set; }
        #region methods
        public FilterJobsResponse SetJobs(List<Domain.Aggregates.JobsAggregates.Job> jobs)
        {
            this.Jobs = jobs;
            return this;
        }
        public FilterJobsResponse SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.EndPage = paging.EndPage;
            this.StartPage = paging.StartPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.SkipEntity = paging.SkipEntity;
            this.TakeEntity = paging.TakeEntity;
            this.PageCount = paging.PageCount;
            return this;
        }
        #endregion
    }
}
