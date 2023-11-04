using AutoMapper;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Application.DTOs;
using MaterialsWarehouse.Application.Specifications;
using MaterialsWarehouse.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsWarehouse.Application.Queries.GetAllMaterialsQuery
{
    internal class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterialsQuery, ResponseResult<IEnumerable<MaterialDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllMaterialsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<MaterialDto>>> Handle(GetAllMaterialsQuery query, CancellationToken cancellationToken)
        {
            var materials = await unitOfWork.Repository<Material>().Find(new AllMaterialsSpecification()).ToListAsync();

            var materialsDto = mapper.Map<IEnumerable<MaterialDto>>(materials);

            return ResponseResult.CreateSuccess(materialsDto);
        }
    }
}
