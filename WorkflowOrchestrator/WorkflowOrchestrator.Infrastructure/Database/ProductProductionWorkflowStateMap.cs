using MassTransit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WorkflowOrchestrator.Domain.Entities;

namespace WorkflowOrchestrator.Infrastructure.Database;

public class ProductProductionWorkflowStateMap : SagaClassMap<ProductProductionWorkflowState>
{
    protected override void Configure(EntityTypeBuilder<ProductProductionWorkflowState> entity, ModelBuilder model)
    {
        base.Configure(entity, model);
    }
}
