using AutoMapper;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Transportations.Application.Commands.TransportMaterialCommand;
using Transportations.Application.Commands.TransportProductCommand;
using Transportations.Application.DTOs;
using Transportations.Domain.Entities;

namespace Transportations.Application.Profiles;

public class TransportationProfile : Profile
{
    public TransportationProfile()
    {
        CreateMap<Transportation, TransportationDto>();
        CreateMap<TransportMaterialCommandEvent, TransportMaterialCommand>();
        CreateMap<TransportProductCommandEvent, TransportProductCommand>();
    }
}