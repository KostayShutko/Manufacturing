using Manufacturing.Common.Domain.Entities;

namespace WorkflowOrchestrator.Application.DTOs;

public class ProductProductionWorkflowDto
{
    public Guid WorkflowId { get; set; }

    public string CurrentState { get; set; }

    public int MaterialId { get; set; }

    public int ProductId { get; set; }

    public int ProcessId { get; set; }

    public ProductCode ProductCode { get; set; }
}