using AutoMapper;
using Manufacturing.Common.Application.EventContracts.Products;
using Manufacturing.Common.Application.EventContracts.Transportations;
using ProductsWarehouse.Application.Commands.CancelProductReservationCommand;
using ProductsWarehouse.Application.Commands.PlaceProductCommand;
using ProductsWarehouse.Application.Commands.ReserveProductCommand;
using ProductsWarehouse.Application.DTOs;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ReserveProductCommandEvent, ReserveProductCommand>();
        CreateMap<ProductTransportedEvent, PlaceProductCommand>();
        CreateMap<CancelProductReservationCommandEvent, CancelProductReservationCommand>();
    }
}
