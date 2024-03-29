﻿using AutoMapper;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Manufacturing.Common.Application.EventContracts.Processes;
using ProcessingMachines.Application.Commands.CreateProcessCommand;
using ProcessingMachines.Application.Commands.StartProcessCommand;
using ProcessingMachines.Application.DTOs;
using ProcessingMachines.Domain.Entities;
using ProcessingMachines.Application.Commands.CancelProcessCommand;

namespace ProcessingMachines.Application.Profiles;

public class ProcessProfile : Profile
{
    public ProcessProfile()
    {
        CreateMap<Process, ProcessDto>();
        CreateMap<MaterialTransportedEvent, CreateProcessCommand>();
        CreateMap<StartProcessingCommandEvent, StartProcessCommand>();
        CreateMap<CancelProcessCommandEvent, CancelProcessCommand>();
    }
}
