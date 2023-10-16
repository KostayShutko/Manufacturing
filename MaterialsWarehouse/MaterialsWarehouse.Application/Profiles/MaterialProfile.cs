using AutoMapper;
using MaterialsWarehouse.Application.DTOs;
using MaterialsWarehouse.Domain.Entities;

namespace MaterialsWarehouse.Application.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile() 
        {
            CreateMap<Material, MaterialDto>();
        }
    }
}
