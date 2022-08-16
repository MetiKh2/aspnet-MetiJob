

using AutoMapper;
using MediatR;
using MetiJob.Application.Enums;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Jobs.Dtos;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Jobs.Queries.GetJob
{
    public class GetJobQueryHandler : IRequestHandler<GetJobQuery, OperationResult<GetJobResponse>>
    {
        private readonly IGenericRepository<Job> _jobRepository;
        private readonly IMapper _mapper;

        public GetJobQueryHandler(IGenericRepository<Job> jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetJobResponse>> Handle(GetJobQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetJobResponse>();
            try
            {
                var job = await _jobRepository.GetQuery().Include(p => p.Company).Where(p => p.Id == request.Id).FirstOrDefaultAsync();
                if(job==null)
                {
                    result.AddError(ErrorCode.NotFound,"Job Not found");
                    return result;
                }
               result.Payload= _mapper.Map<GetJobResponse>(job);
               result.Payload.JobCompanyProperties = _mapper.Map<JobCompanyProperties>(job.Company);
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
                throw;
            }
            return result;
        }
    }
}
