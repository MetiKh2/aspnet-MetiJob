using MetiJob.Application.Paging;

namespace MetiJob.Api.Contracts.Companies
{
    public class FilterCompaniesRequest:BasePaging
    {
        public bool IsHot { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? OrderBy{ get; set; }
    }
}
