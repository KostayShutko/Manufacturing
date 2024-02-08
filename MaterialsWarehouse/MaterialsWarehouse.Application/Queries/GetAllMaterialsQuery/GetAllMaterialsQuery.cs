using Manufacturing.Common.Application.ResponseResults;
using MaterialsWarehouse.Application.DTOs;
using MediatR;

namespace MaterialsWarehouse.Application.Queries.GetAllMaterialsQuery;

public class GetAllMaterialsQuery : IRequest<ResponseResult<IEnumerable<MaterialDto>>>
{
}
