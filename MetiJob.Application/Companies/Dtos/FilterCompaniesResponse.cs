

using MetiJob.Application.Paging;

namespace MetiJob.Application.Companies.Dtos
{
    public class FilterCompaniesResponse:BasePaging
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? OrderBy{ get; set; }
        public bool IsHot { get; set; }
        public List<Domain.Aggregates.JobsAggregates.Company> Companies{ get; set; }
        #region methods
        public FilterCompaniesResponse SetCompanies(List<Domain.Aggregates.JobsAggregates.Company> companies)
        {
            this.Companies = companies;
            return this;
        }
        public FilterCompaniesResponse SetPaging(BasePaging paging)
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
