


using MediatR;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Models;

namespace MetiJob.Application.Jobs.Queries.GetJob
{
    public class GetJobQuery:IRequest<OperationResult<GetJobResponse>>
    {
        public long Id { get; set; }

        public GetJobQuery(long id)
        {
            Id = id;
        }
    }
}
