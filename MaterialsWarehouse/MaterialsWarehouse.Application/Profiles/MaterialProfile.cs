using AutoMapper;
using Manufacturing.Common.Application.EventContracts.Materials;
using MaterialsWarehouse.Application.Commands.ReserveMaterialCommand;
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
        }
    }
}
