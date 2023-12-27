using AutoMapper;
using Manufacturing.Common.Application.Queries;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Application.DTOs;
using MaterialsWarehouse.Application.Specifications;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Queries.GetAllMaterialsQuery
{
    internal class GetAllMaterialsQueryHandler : BaseQuery<Material>, IRequestHandler<GetAllMaterialsQuery, ResponseResult<IEnumerable<MaterialDto>>>
    {
        private readonly IMapper mapper;

        public GetAllMaterialsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            this.mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<MaterialDto>>> Handle(GetAllMaterialsQuery query, CancellationToken cancellationToken)
        {
            var materials = await FindBySpecificationAsync(new AllMaterialsSpecification());

            var materialsDto = mapper.Map<IEnumerable<MaterialDto>>(materials);

            return ResponseResult.CreateSuccess(materialsDto);
        }
    }
}
