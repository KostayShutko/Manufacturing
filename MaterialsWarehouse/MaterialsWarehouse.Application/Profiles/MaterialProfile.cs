using AutoMapper;
using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.EventContracts.Transportations;
using MaterialsWarehouse.Application.Commands.ReserveMaterialCommand;
using MaterialsWarehouse.Application.Commands.TransportMaterialCommand;
using MaterialsWarehouse.Application.DTOs;
using MaterialsWarehouse.Domain.Entities;

namespace MaterialsWarehouse.Application.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile() 
        {
            CreateMap<Material, MaterialDto>();
            CreateMap<ReserveMaterialCommandEvent, ReserveMaterialCommand>();
            CreateMap<MaterialTransportedEvent, TransportMaterialCommand>();
        }
    }
}
