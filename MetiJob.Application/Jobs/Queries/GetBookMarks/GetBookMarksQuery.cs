

using MediatR;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Models;

namespace MetiJob.Application.Jobs.Queries.GetBookMarks
{
    public class GetBookMarksQuery:IRequest<OperationResult<List<AppliedResponse>>>
    {
        public string UserId { get; set; }

        public GetBookMarksQuery(string userId)
        {
            UserId = userId;
        }
    }
}
