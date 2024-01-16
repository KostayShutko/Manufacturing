using Manufacturing.Common.Domain.Entities;
using ProcessingMachines.Domain.BusinessRules;
using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Domain.Entities;

public class Process : Entity
{
    public Process() { }

    public Process(int materialId)
    {
        State = ProcessState.Ready;
        MaterialId = materialId;
    }

    public ProcessState State { get; set; }

    public int MaterialId { get; set; }

    public DateTime? StartedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    public ProductCode ProductCode { get; set; }

    public Product? Product { get; set; }

    public IEnumerable<ProcessingOperation>? OperationsPlan { get; set; }

    public static Process Create(int materialId, Guid workflowId)
    {
        var process = new Process(materialId);

        process.AssignWorkflow(workflowId);

        return process;
    }

    public void StartExecution()
    {
        CheckRule(new ProcessMustBeReadyToExecuteRule(State));
        CheckRule(new ProcessMustHaveOperationsPlanRule(OperationsPlan));

        State = ProcessState.InProgress;
        StartedOn = DateTime.UtcNow;
    }

    public void Complete()
    {
        CheckRule(new ProcessMustBeInProgressRule(State));
        CheckRule(new ProductMustHaveAppliedOperationsRule(Product?.AppliedOperations));

        State = ProcessState.Completed;
        CompletedOn = DateTime.UtcNow;
    }

    public void PlanProduction(ProductCode productCode, IEnumerable<ProcessingOperation> plan)
    {
        ProductCode = productCode;
        OperationsPlan = plan;
    }
}
