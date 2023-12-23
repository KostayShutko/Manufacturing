using Manufacturing.Common.Application.ResponseResults;
using MediatR;
using ProcessingMachines.Application.DTOs;

namespace ProcessingMachines.Application.Queries.GetAllProcessesQuery;

public class GetAllProcessesQuery : IRequest<ResponseResult<IEnumerable<ProcessDto>>>
{
}
