using MetiJob.Application.Paging;

namespace MetiJob.Api.Contracts.Companies
{
    public class FilterCompaniesRequest:BasePaging
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? OrderBy{ get; set; }
    }
}
