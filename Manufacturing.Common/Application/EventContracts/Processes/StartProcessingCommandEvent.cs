using Manufacturing.Common.Domain.Entities;

namespace Manufacturing.Common.Application.EventContracts.Processes;

public class StartProcessingCommandEvent : BaseEvent
{
    public StartProcessingCommandEvent(int processId, ProductCode productCode, Guid workflowId)
        : base(workflowId)
    {
        ProcessId = processId;
        ProductCode = productCode;
    }

    public int ProcessId { get; set; }

    public ProductCode ProductCode { get; set; }
}
