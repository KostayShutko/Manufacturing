using AutoMapper;
using Manufacturing.Common.Repository;
using MaterialsWarehouse.Application.DTOs;
using MaterialsWarehouse.Application.Specifications;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Queries.GetAllMaterialsQuery
{
    internal class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterialsQuery, IEnumerable<MaterialDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllMaterialsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDto>> Handle(GetAllMaterialsQuery query, CancellationToken cancellationToken)
        {
            var materials = await unitOfWork.Repository<Material>().FindAsync(new LastMaterialSpecification());

            return mapper.Map<IEnumerable<MaterialDto>>(materials);
        }
    }
}
