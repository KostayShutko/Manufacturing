using MaterialsWarehouse.Application.DTOs;
using MediatR;

namespace MaterialsWarehouse.Application.Queries.GetAllMaterialsQuery
{
    public class GetAllMaterialsQuery : IRequest<IEnumerable<MaterialDto>>
    {
    }
}
