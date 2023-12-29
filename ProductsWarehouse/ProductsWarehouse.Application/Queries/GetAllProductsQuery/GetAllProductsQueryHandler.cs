using AutoMapper;
using Manufacturing.Common.Application.Queries;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProductsWarehouse.Application.DTOs;
using ProductsWarehouse.Application.Specifications;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Application.Queries.GetAllProductsQuery;

public class GetAllProductsQueryHandler : BaseQuery<Product>, IRequestHandler<GetAllProductsQuery, ResponseResult<IEnumerable<ProductDto>>>
{
    private readonly IMapper mapper;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork)
    {
        this.mapper = mapper;
    }

    public async Task<ResponseResult<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await FindBySpecificationAsync(new AllProductsSpecification());

        var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);

        return ResponseResult.CreateSuccess(productsDto);
    }
}
