using AutoMapper;
using WorkflowOrchestrator.Application.DTOs;
using WorkflowOrchestrator.Domain.Entities;

namespace WorkflowOrchestrator.Application.Profiles;

public class WorkflowProfile : Profile
{
    public WorkflowProfile()
    {
        CreateMap<ProductProductionWorkflowState, ProductProductionWorkflowDto>();
    }
}