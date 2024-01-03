using Manufacturing.Common.Application.ResponseResults;
using MediatR;
using Transportations.Application.DTOs;

namespace Transportations.Application.Queries.GetAllTransportationsQuery;

public class GetAllTransportationsQuery : IRequest<ResponseResult<IEnumerable<TransportationDto>>>
{
}
