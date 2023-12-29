using Manufacturing.Common.Application.ResponseResults;
using MediatR;
using ProductsWarehouse.Application.DTOs;

namespace ProductsWarehouse.Application.Queries.GetAllProductsQuery;

public class GetAllProductsQuery : IRequest<ResponseResult<IEnumerable<ProductDto>>>
{
}
