 

namespace MetiJob.Application.Jobs.Queries.GetLastJobsForCompany
{
    public class GetLastJobsForCompanyQuery
    {
        public long CompanyId { get; set; }

        public GetLastJobsForCompanyQuery(long companyId)
        {
            CompanyId = companyId;
        }
    }
}
