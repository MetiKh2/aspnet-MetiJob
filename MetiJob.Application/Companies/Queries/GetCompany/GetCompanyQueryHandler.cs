

using AutoMapper;
using MediatR;
using MetiJob.Application.Companies.Dtos;
using MetiJob.Application.GenericRepository;
using MetiJob.Application.Models;
using MetiJob.Domain.Aggregates.JobsAggregates;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, OperationResult<GetCompanyResponse>>
    {
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(IGenericRepository<Company> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<GetCompanyResponse>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetCompanyResponse>();
            try
            {
                if (await _companyRepository.IsExist(request.Id))
                {
                    var company=await _companyRepository.GetQuery().Include(p=>p.Jobs).Where(p=>p.Id==request.Id).FirstOrDefaultAsync();
                    result.Payload = _mapper.Map<GetCompanyResponse>(company);
                }
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}
