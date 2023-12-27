using AutoMapper;
using Manufacturing.Common.Application.Queries;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Application.DTOs;
using ProcessingMachines.Application.Specifications;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Queries.GetAllProcessesQuery;

public class GetAllProcessesQueryHandler : BaseQuery<Process>, IRequestHandler<GetAllProcessesQuery, ResponseResult<IEnumerable<ProcessDto>>>
{
    private readonly IMapper mapper;

    public GetAllProcessesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork)
    {
        this.mapper = mapper;
    }

    public async Task<ResponseResult<IEnumerable<ProcessDto>>> Handle(GetAllProcessesQuery query, CancellationToken cancellationToken)
    {
        var processes = await FindBySpecificationAsync(new AllProcessesSpecification());

        var processesDto = mapper.Map<IEnumerable<ProcessDto>>(processes);

        return ResponseResult.CreateSuccess(processesDto);
    }
}
