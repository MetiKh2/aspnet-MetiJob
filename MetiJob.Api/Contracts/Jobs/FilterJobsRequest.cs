using MetiJob.Application.Paging;

namespace MetiJob.Api.Contracts.Jobs
{
    public class FilterJobsRequest:BasePaging
    {
        public string? Title { get; set; }
        public string? CompanyName { get; set; }
        public  string? State { get; set; }
        public  string? ContractsCategories { get; set; }
        public  string? JobCategory { get; set; }
        public  string? WorkExperience { get; set; }
        public long? MinPrice{ get; set; }
        public bool IsHot { get; set; }
        #region methods
         
       
        #endregion
    }
}
