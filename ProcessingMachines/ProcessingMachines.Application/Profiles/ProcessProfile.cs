using AutoMapper;
using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.EventContracts.Processes;
using ProcessingMachines.Application.Commands.CreateProcessCommand;
using ProcessingMachines.Application.Commands.StartProcessCommand;
using ProcessingMachines.Application.DTOs;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Profiles;

public class ProcessProfile : Profile
{
    public ProcessProfile()
    {
        CreateMap<Process, ProcessDto>();
        CreateMap<MaterialTransportedEvent, CreateProcessCommand>();
        CreateMap<StartProcessCommandEvent, StartProcessCommand>();
    }
}
