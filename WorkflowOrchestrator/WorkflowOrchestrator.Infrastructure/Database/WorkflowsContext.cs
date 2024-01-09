using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace WorkflowOrchestrator.Infrastructure.Database;

public class WorkflowsContext : SagaDbContext
{
    public WorkflowsContext(DbContextOptions options) : base(options)
    {
    }

    protected override IEnumerable<ISagaClassMap> Configurations
    {
        get
        {
            yield return new ProductProductionWorkflowStateMap();
        }
    }
}