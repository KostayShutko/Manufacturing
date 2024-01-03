using AutoMapper;
using Transportations.Application.DTOs;
using Transportations.Domain.Entities;

namespace Transportations.Application.Profiles;

public class TransportationProfile : Profile
{
    public TransportationProfile()
    {
        CreateMap<Transportation, TransportationDto>();
    }
}