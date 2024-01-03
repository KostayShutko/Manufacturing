using AutoMapper;
using Manufacturing.Common.Application.Queries;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using Transportations.Application.DTOs;
using Transportations.Application.Specifications;
using Transportations.Domain.Entities;

namespace Transportations.Application.Queries.GetAllTransportationsQuery;

public class GetAllTransportationsQueryHandler : BaseQuery<Transportation>, IRequestHandler<GetAllTransportationsQuery, ResponseResult<IEnumerable<TransportationDto>>>
{
    private readonly IMapper mapper;

    public GetAllTransportationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork)
    {
        this.mapper = mapper;
    }

    public async Task<ResponseResult<IEnumerable<TransportationDto>>> Handle(GetAllTransportationsQuery query, CancellationToken cancellationToken)
    {
        var transportations = await FindBySpecificationAsync(new AllTransportationsSpecification());

        var transportationsDto = mapper.Map<IEnumerable<TransportationDto>>(transportations);

        return ResponseResult.CreateSuccess(transportationsDto);
    }
}