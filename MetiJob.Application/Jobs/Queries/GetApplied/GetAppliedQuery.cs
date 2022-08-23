

using MediatR;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Models;

namespace MetiJob.Application.Jobs.Queries.GetApplied
{
    public class GetAppliedQuery:IRequest<OperationResult<List<AppliedResponse>>>
    {
        public string UserId { get; set; }
        public string Type { get; set; }

        public GetAppliedQuery(string type, string userId)
        {
            Type = type;
            UserId = userId;
        }
    }
}
