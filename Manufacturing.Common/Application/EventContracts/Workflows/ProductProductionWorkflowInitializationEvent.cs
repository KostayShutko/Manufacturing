using Manufacturing.Common.Domain.Entities;

namespace Manufacturing.Common.Application.EventContracts.Workflows;

public class ProductProductionWorkflowInitializationEvent : BaseEvent
{
    public ProductProductionWorkflowInitializationEvent(ProductCode productCode, Guid workflowId)
        : base(workflowId)
    {
        ProductCode = productCode;
    }

    public ProductCode ProductCode { get; set; }
}

