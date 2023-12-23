using AutoMapper;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProcessingMachines.Application.DTOs;
using ProcessingMachines.Application.Specifications;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Queries.GetAllProcessesQuery;

public class GetAllProcessesQueryHandler : IRequestHandler<GetAllProcessesQuery, ResponseResult<IEnumerable<ProcessDto>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllProcessesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ResponseResult<IEnumerable<ProcessDto>>> Handle(GetAllProcessesQuery query, CancellationToken cancellationToken)
    {
        var processes = await unitOfWork.Repository<Process>().Find(new AllProcessesSpecification()).ToListAsync();

        var processesDto = mapper.Map<IEnumerable<ProcessDto>>(processes);

        return ResponseResult.CreateSuccess(processesDto);
    }
}
